    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace LinqAnswer
    {
        public class Student
        {
            public int Age { get; set; }
            public string Name { get; set; }
            public List<Course> Courses { get; set; } = new List<Course>();
    
            public void AddCourse(Course course)
            {
                Courses.Add(course);
            }
        }
    
        public class Course
        {
            public int Id { get; set; }
            public string Name { get; set; }
    
            public List<Subject> Subjects { get; set; } = new List<Subject>();
    
            public void AddSubject(Subject subject)
            {
                Subjects.Add(subject);
            }
        }
    
        public class Subject
        {
            public string Name { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var students = new List<Student>
                {
                    new Student { Age = 18, Name = "A" },
                    new Student { Age = 19, Name = "B" },
                    new Student { Age = 21, Name = "C" },
                    new Student { Age = 22, Name = "D" },
                    new Student { Age = 20, Name = "E" }
                };
                var courses = new List<Course>
                {
                    new Course { Id = 1, Name = "C1" },
                    new Course { Id = 2, Name = "C2" },
                    new Course { Id = 3, Name = "C3" },
                    new Course { Id = 4, Name = "C4" }
                };
                var subjects = new List<Subject>
                {
                    new Subject { Name = "S1" },
                    new Subject { Name = "S2" },
                    new Subject { Name = "S3" }
                };
                students[0].AddCourse(courses[0]);
                students[0].AddCourse(courses[2]);
                students[1].AddCourse(courses[3]);
                students[2].AddCourse(courses[0]);
                students[2].AddCourse(courses[3]);
                students[3].AddCourse(courses[2]);
                students[4].AddCourse(courses[1]);
    
                courses[0].AddSubject(subjects[0]);
                courses[0].AddSubject(subjects[1]);
                courses[1].AddSubject(subjects[0]);
                courses[2].AddSubject(subjects[1]);
                courses[2].AddSubject(subjects[2]);
                courses[3].AddSubject(subjects[2]);
    
                var studentsWithSubjectS2 = from student in students
                                            from course in student.Courses
                                            where course.Subjects.IndexOf(subjects[2]) >= 0
                                            select student;
                foreach(var studentWithSubjectS2 in studentsWithSubjectS2)
                {
                    Console.WriteLine($"{studentWithSubjectS2.Name}, Age={studentWithSubjectS2.Age}");
                }
            }
        }
    }
