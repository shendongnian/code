                Console.WriteLine("Please type your date of birth");
                var DOB = Console.ReadLine();
                TimeSpan ts =DateTime.Now - Convert.ToDateTime(DOB) ;
                Console.WriteLine("you are " + Math.Round (ts.TotalDays / 365) + " years old.");
                Console.ReadLine();
