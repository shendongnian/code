    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Student student = new Student();
                List<Student> students = student.GetStuCosineSimilarity();
                int[] ids = students.Select(x => x.Id).ToArray();
            }
        }
        static public class DB
        {
            public static List<Student> Students { get; set; } 
        }
        public class Student
        {
            public int Id { get; set; }
            public double? Cosine { get; set; }
            public List<Student> GetStuCosineSimilarity()
            {
                List<Student> lst = new List<Student>();
                lst = (from s in DB.Students
                       select new Student()
                       {
                           Id = s.Id,
                           Cosine = s.Cosine
                       }).ToList();
                lst = lst.OrderBy(k => k.Cosine).ToList(); // Sorting the float value
                return lst;
            }
        }
    }
