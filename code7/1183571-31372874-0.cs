    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Student> students = new List<Student>() {
                       new Student(new List<int>() {100,103,106}) { StudentId = 1001, Name = "John"}, 
                       new Student(new List<int>() {101,104,105}) { StudentId = 1002, Name = "Mary"},
                       new Student(new List<int>() {102,105,104}) { StudentId = 1003, Name = "Tom"},
                       new Student(new List<int>() {103,106,102}) { StudentId = 1004, Name = "Dick"},
                       new Student(new List<int>() {104,101,102}) { StudentId = 1005, Name = "Harry"}
                    };
         
                Dictionary<int, Student> dictStudents = students.AsEnumerable()
                    .GroupBy(x => x.StudentId, y => y)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                foreach (KeyValuePair<int, Student> student in dictStudents)
                {
                    string message = String.Format("<br />Student ID: {0}  Student Name: {1} Courses: {2}", 
                        student.Key.ToString(),
                        student.Value.Name,
                        string.Join(",", student.Value.Courses.Select(x => "CourseID=" + x.CourseID.ToString() + ":" + "Course Name= " + x.Name).ToArray()));
                    Console.WriteLine(message);
                }
                Console.ReadLine();
                
            }
        }
        public class Student
        {
            public int StudentId { get; set; }
            public string Name { get; set; }
            public List<Course> Courses { get; set; }
     
            public Student() { Courses = new List<Course>();}
            public Student(List<int> couseNumbers)
            {
                Courses = new List<Course>();
                foreach(int id in couseNumbers)
                {
                    Courses.Add(Course.courses.Where(x => x.CourseID == id).FirstOrDefault()); 
                }
            }
        }
        public class Course
        {
            public static List<Course> courses = new List<Course>() {
                    new Course() {CourseID = 100, Name = "abc"},
                    new Course() {CourseID = 101, Name = "abd"},
                    new Course() {CourseID = 102, Name = "abe"},
                    new Course() {CourseID = 103, Name = "abf"},
                    new Course() {CourseID = 104, Name = "abg"},
                    new Course() {CourseID = 105, Name = "abh"},
                    new Course() {CourseID = 106, Name = "abi"}
            };
            public int CourseID { get; set; }
            public string Name { get; set; }
        }
    }
    ​
