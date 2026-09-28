using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstWeekTask
{
    internal class Program
    {

        static void Main(string[] args)
        {
            studentManager studentmanager = new studentManager();
            studentmanager.add();
            //Console.WriteLine(std.name);
            //Console.WriteLine(std.age);
            //Console.WriteLine(std.courseId);
            //Console.WriteLine(std.id);


            Console.WriteLine("Do you need to add again student? Y/N");

            string ans = Console.ReadLine();

            while (ans.ToLower() == "y")
            {

                studentmanager.add();
                Console.WriteLine("Do you need to add again student? Y/N");
                ans = Console.ReadLine();
            }

            foreach (Student student in studentmanager.students)
            {
                Console.WriteLine(student.name);
                Console.WriteLine(student.age);
            }

            Console.WriteLine("If you wanna update any student enter the student ID or not enter no :  ");

            int sId = Convert.ToInt32(Console.ReadLine());

            var update = studentmanager.students.FirstOrDefault(id => id.id == sId);

            if (update != null)
            {
                Console.WriteLine($"update {update.name}'s details");
                Console.WriteLine("Edit student name");
                string name = Console.ReadLine();

                Console.WriteLine("Edit student age");
                string age = Console.ReadLine();
                int studentAge = Convert.ToInt32(age);

                Console.WriteLine("Edit student id");
                string id = Console.ReadLine();
                int studentid = Convert.ToInt32(id);

                Console.WriteLine("Edit Course Id");
                int courseid = Convert.ToInt32(Console.ReadLine());

                update.name = name;
                update.age = studentAge;
                update.id = studentid;
                update.courseId = courseid;

                foreach (Student student in studentmanager.students)
                {
                    Console.WriteLine(student.name);
                    Console.WriteLine(student.age);
                }
            }

            Console.WriteLine("If you wanna delete any student details enter the student ID  :  ");

            int dId = Convert.ToInt32(Console.ReadLine());

            var dlt = studentmanager.students.FirstOrDefault(id => id.id == sId);

            if (dlt != null)
            {
                studentmanager.students.Remove(dlt);

                foreach (Student student in studentmanager.students)
                {
                    Console.WriteLine(student.name);
                    Console.WriteLine(student.age);
                }
            }
            Console.WriteLine("Do you wanna add course? Enter Y/N");
            string result = Console.ReadLine();

            if (result.ToLower() == "y")
            {
                //course managing
                courseManager crs = new courseManager();

                crs.AddCourse();

                foreach(Course item in crs.courses)
                {
                    Console.WriteLine(item.courseName);
                    Console.WriteLine(item.courseId);
                }



            }

            Console.WriteLine("If you wanna filter  students based on age enter the student age limit  :  ");

            int fId = Convert.ToInt32(Console.ReadLine());

            var filt = studentmanager.students.Where(student => student.age >= fId);

            foreach(var item in filt)
            {
                Console.WriteLine(item.name);
                Console.WriteLine(item.age);

            }
        }



    }
    public class Student
    {
        public int id;
        public string name;
        public int age;
        public int courseId;

    }

    class Course
    {
        public string courseName;
        public int courseId;
    }

    class studentManager
    {
        public List<Student> students = new List<Student>();
        public void add()
        {
            Console.WriteLine("Enter student name");
            string name = Console.ReadLine();

            Console.WriteLine("Enter student age");
            string age = Console.ReadLine();
            int studentAge = Convert.ToInt32(age);

            Console.WriteLine("enter student id");
            string id = Console.ReadLine();
            int studentid = Convert.ToInt32(id);

            Console.WriteLine("Enter Course Id");
            int courseid = Convert.ToInt32(Console.ReadLine());

            Student createdStudent = new Student();

            createdStudent.name = name;
            createdStudent.id = studentid;
            createdStudent.courseId = courseid;
            createdStudent.age = studentAge;


            students.Add(createdStudent);
           
        }

    }
    class courseManager
    {
        public List<Course> courses = new List<Course>();
        public Course AddCourse()
        {
            Console.WriteLine("Enter new course");
            string name = Console.ReadLine();

            Console.WriteLine("Set course Id ");
            int id = Convert.ToInt32(Console.ReadLine());

            Course course = new Course();

            course.courseName = name;
            course.courseId = id;

            courses.Add(course);

            return course;
        }
    }


}
