        static void Main(string[] args)
        {
           
            string firstName, lastName, grade;
            double score, percent;
            //inputs
            Console.WriteLine("Please enter your first name");
            firstName = Console.ReadLine();
            Console.WriteLine("Please enter your last name:");
            lastName = Console.ReadLine();
            Console.Write("Please enter a score: ");
            score = Convert.ToDouble(Console.ReadLine());
                       
            //processes
            if (score < 0 || score > 1000)
            {
                Console.WriteLine("Invalid Score");
            }
            else
            {
                percent = score / 1000;
                if (percent >= .9)
                {
                    grade = "A";
                }
                else
                {
                    if (percent >= .8)
                    {
                        grade = "B";
                    }
                    else
                    {
                        if (percent >= .7)
                        {
                            grade = "C";
                        }
                        else
                        {
                            if (percent >= .6)
                            {
                                grade = "D";
                            }
                            else
                            {
                                grade = "F";
                            }
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("\n\n========================================================");
                    Console.WriteLine("Name: " + firstName + " " + lastName);
                    Console.WriteLine("Your precentage is " + percent.ToString("P"));
                    Console.WriteLine("Your letter grade is: " + grade);
                }
            }
            Console.ReadLine();
        }
