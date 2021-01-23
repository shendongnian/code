    namespace stackOverflow
    {
        class Program
        {
            static void Main(string[] args)
            {
                course c = new course();
                student student1 = new student("a");
                student student2 = new student("b");
                student student3 = new student("c");
                c.students.Add(student1);
                c.students.Add(student2);
                c.students.Add(student3);
    
                foreach (object o in c.students)
                {
                    student s = (student)o;
                    Console.WriteLine(s.name);
                }
                
            }
        }
        class course
        {
    
           public List<student> students = new List<student>();
        }
        class student
        {
            public string name { get; set; }
            public student(string s)
            {
                name = s;
            }
        }
    }
