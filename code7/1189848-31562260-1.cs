    namespace ConsoleApplication1
    {
    
        class Student
        {
            //Members of class
            public int Year;
            public int Class;
            public string FirstName;
            public string LastName;
            public int Average;
    
            /// <summary>
            /// Gets a line and creates a student object
            /// </summary>
            /// <param name="line">The line to be parsed</param>
            public Student(string line)
            {
                //being parsing
    
                //split by space
                List<String> unfiltered = new List<string>(line.Split(' '));
    
                //a list to save filtered data
                List<string> filtred = new List<string>();
    
                //filter out empty spaces...
                //There exist much smarter ways...but this does the job 
                foreach (string entry in unfiltered)
                {
                    if (!String.IsNullOrWhiteSpace(entry))
                        filtred.Add(entry);
                }
    
                //Set variables
                Year = Convert.ToInt32(filtred[0]);
                Class = Convert.ToInt32(filtred[1]);
                FirstName = filtred[2];
                LastName = filtred[3];
                Average = Convert.ToInt32(filtred[4]);
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var data = System.IO.File.ReadAllLines(@"d:\data.txt");
    
                //a list to hold students
                List<Student> students = new List<Student>();
    
                foreach (var line in data)
                {
                    //create a new student and add it to list
                    students.Add(new Student(line));
                }
    
                //to test, write all names
                foreach (var student in students)
                {
                    Console.WriteLine(student.FirstName + " " + student.LastName + Environment.NewLine);
                }
    
                //you can calculate average of all students averages!
                int sum = 0;
                for (int i = 0; i < students.Count; i++)
                {
                    sum += students[i].Average;
                }
    
                //print average of all students
                Console.WriteLine("Average mark of all students: " + (sum / students.Count));
    
                Console.ReadKey();
            }
        }
    }
