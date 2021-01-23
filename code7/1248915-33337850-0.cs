    namespace Combine
    {
        using System;
    
        public class LetterGradeProgram
        {
            public void Execute()
            {
                int marks;
                string grade = null;
    
                Console.WriteLine("Please enter your mark here");
                marks = int.Parse(Console.ReadLine());
    
                if (marks < 0 || marks > 100)
                {
                    Console.WriteLine("mark entered is not valid");
                }
                else
                {
                    if (marks >= 85 && marks <= 100)
                    {
                        grade = "A";
                    }
                    else if (marks >= 70 && marks <= 84)
                    {
                        grade = "B";
                    }
                    else if (marks >= 60 && marks <= 69)
                    {
                        grade = "C";
                    }
                    else if (marks >= 50 && marks <= 59)
                    {
                        grade = "D";
                    }
                    else if (marks >= 0 && marks <= 49)
                    {
                        grade = "F";
                    }
    
                    Console.WriteLine("grade is a " + grade + " grade");
                }
    
                Console.ReadLine();
            }
        }
    
        public class BodyMassIndexProgram
        {
            public void Execute()
            {
                // do something here
            }
        }
    
        public class TaxDueProgram
        {
            public void Execute()
            {
                // do something here
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Program p = new Program();
                Console.WriteLine("Welcome");
                Console.WriteLine("Please Select A Menu Item");
                Console.WriteLine("B - Body Mass Index");
                Console.WriteLine("T - Tax Due");
                Console.WriteLine("L - Letter Grade");
    
                string selected = Console.ReadLine();
                switch (selected.ToUpperInvariant())
                {
                    case "B":
                        BodyMassIndexProgram bodyMassIndex = new BodyMassIndexProgram();
                        bodyMassIndex.Execute();
                        break;
                    case "T":
                        TaxDueProgram taxDue = new TaxDueProgram();
                        taxDue.Execute();
                        break;
                    case "L":
                        LetterGradeProgram letterGrade = new LetterGradeProgram();
                        letterGrade.Execute();
                        break;
                    default:
                        Console.WriteLine("Unknown option {0}", selected);
                        break;
                }
    
                Console.WriteLine("Bye");
            }
        }
    }
