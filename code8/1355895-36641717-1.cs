    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Demo
    {
        public class Student
        {
            public string Name { get; set; }
            public List<ExamScore> ExamScores { get; set; }
        }
        public class Subject
        {
            public string Name { get; set; }
        }
        public class ExamScore
        {
            public Subject Subject 
            {
                get;
                set;
            }
            public int Score { get; set; }
        }
        static class Program
        {
            static void Main()
            {
                var students = new List<Student>
                {
                    new Student
                    {
                        Name = "C",
                        ExamScores = new List<ExamScore>
                        {
                            new ExamScore {Subject = new Subject {Name = "Z"}, Score = 1},
                            new ExamScore {Subject = new Subject {Name = "Y"}, Score = 2},
                            new ExamScore {Subject = new Subject {Name = "X"}, Score = 3},
                        }
                    },
                    new Student
                    {
                        Name = "B",
                        ExamScores = new List<ExamScore>
                        {
                            new ExamScore {Subject = new Subject {Name = "Z"}, Score = 4},
                            new ExamScore {Subject = new Subject {Name = "Y"}, Score = 5},
                            new ExamScore {Subject = new Subject {Name = "X"}, Score = 6},
                        }
                    },
                    new Student
                    {
                        Name = "A",
                        ExamScores = new List<ExamScore>
                        {
                            new ExamScore {Subject = new Subject {Name = "Z"}, Score = 7},
                            new ExamScore {Subject = new Subject {Name = "Y"}, Score = 8},
                            new ExamScore {Subject = new Subject {Name = "X"}, Score = 9},
                        }
                    }
                };
                var orderedStudents = 
                    students.SelectMany(s => s.ExamScores.Select(e => new {Student = s, ExamScore = e}))
                    .OrderBy(x => x.Student.Name)
                    .ThenBy(x => x.ExamScore.Subject.Name);
                foreach (var item in orderedStudents)
                {
                    Console.WriteLine($"{item.Student.Name} {item.ExamScore.Subject.Name} {item.ExamScore.Score}");
                }
            }
        }
    }
