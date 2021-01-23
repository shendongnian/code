    using System;
    using System.Collections.Generic;
    
    namespace Example
    {
        public class Course
        {
            public string CourseTitle { get; set; }
    
            public List<Student> Students { get; set; }
    
            public Course(string courseTitle)
            {
                CourseTitle = courseTitle;
                Students = new List<Student>();
            }
        }
    
        public class Student
        {
            public string Name { get; set; }
    
            public Student(string name)
            {
                Name = name;
            }
        }
    
        public class Teacher
        {
            public string Name { get; set; }
    
            public List<Course> Courses { get; set; }
    
            public Teacher(string name)
            {
                Name = name;
                Courses = new List<Course>();
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                List<Teacher> teachers = new List<Teacher>();
    
                Course course1 = new Course("Astrophysics A");
                Course course2 = new Course("Coding C#");
    
                Student student1 = new Student("Peter");
                Student student2 = new Student("Bill");
                Student student3 = new Student("Anna");
    
                Teacher teacher1 = new Teacher("Mr. Williams");
                Teacher teacher2 = new Teacher("Mr. Jacobson");
    
                course1.Students.Add(student1);
                course1.Students.Add(student3);
    
                course2.Students.Add(student2);
    
                teacher1.Courses.Add(course1);
                teacher2.Courses.Add(course2);
    
                teachers.Add(teacher1);
                teachers.Add(teacher2);
    
                foreach (Teacher teacher in teachers)
                {
                    foreach (Course course in teacher.Courses)
                    {
                        foreach (Student student in course.Students)
                        {
                            Console.WriteLine("{0} and {1} are in {2}", student.Name, teacher.Name, course.CourseTitle);
                        }
                    }
                }
    
                Console.ReadLine();
            }
        }
    }
