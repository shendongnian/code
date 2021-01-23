    namespace Repeat
    {
        class Program
        {
            static void Main(string[] args)
            {
                //VARIABLES         
                float numberOfStudents;
                float numberOfTests;
                float average = 0;
                float grade;
                float sum = 0;
                string studentName;
    
                Console.WriteLine("Type the number of students");
                float.TryParse(Console.ReadLine(), out numberOfStudents);
                Console.WriteLine("Type the number of tests");
                float.TryParse(Console.ReadLine(), out numberOfTests);
    
                Console.WriteLine("");
    
                for (int i = 1; i <= numberOfStudents; i++)
                {
                    sum = 0;
                    Console.Write("Student name {0}: ", i);
                    studentName = Console.ReadLine();
    
                    for (int p = 1; p <= numberOfTests; p++)
                    {
                        Console.Write("Test {0} grade: ", p);
                        float.TryParse(Console.ReadLine(), out grade);
                        sum = sum + grade;
                        average = sum / numberOfTests;
                    }
    
                    if (average < 7)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Average: " + average);
                        Console.ResetColor();
                    }
                    else if (average >= 7)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Average: " + average);
                        Console.ResetColor();
                    }
    
                    Console.WriteLine("");
                }
                Console.ReadKey();
            }
    
        }
    }
