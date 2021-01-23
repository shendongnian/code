        static void Main(string[] args)
        {
            string First;
            string Last;
            First = "Cristiano";
            Last = " Ronaldo";
            Console.Write("Please enter student name <First Last>: ");
            Console.WriteLine(First + Last);
            Console.WriteLine(" ");
            Console.WriteLine("*************NOTE**********************************************");
            Console.WriteLine("*** Be sure to include decimal point for scores.            ***");
            Console.WriteLine("***     !!!All score should range from 0.00 to 100.00 !!    ***");
            Console.WriteLine("***                                                         ***");
            Console.WriteLine("*** For example : 80.50                                     ***");
            Console.WriteLine("***************************************************************");
            Console.WriteLine(" ");
            double Exam_1 = -1;
            double Exam_2;
            double Exam_3;
            double Assignment_1;
            double Assignment_2;
            Console.Write("Please enter score for Exam 1 <Example: 100.0>: ");
            Exam_1 = Convert.ToDouble(Console.ReadLine());
            var exitProgram = false;
            var errorCount = 0;
            while (Exam_1 < 0.0 || Exam_1 > 100.0)
            {
                Console.Write("Exam score cannot be less than 0. or greater than 100.0. Please re-enter the score for Exam 1 <Example: 95.0>:");
                Exam_1 = Convert.ToDouble(Console.ReadLine());
                ++errorCount;
                ErrorCount(errorCount);
            }
            Console.Write("Please enter score for Exam 2 <Example: 0.0>: ");
            Exam_2 = Convert.ToDouble(Console.ReadLine());
            errorCount = 0;
            while (Exam_2 < 0.0 || Exam_2 > 100.0)
            {
                Console.Write("Exam score cannot be less than 0.0 or greater than 100.0. Please re-enter the score for Exam 2 <Example: 95.0>:");
                Exam_2 = Convert.ToDouble(Console.ReadLine());
                ++errorCount;
                ErrorCount(errorCount);
            }
            Console.Write("Please enter score for Exam 3 <Example: 60.8>: ");
            Exam_3 = Convert.ToDouble(Console.ReadLine());
            errorCount = 0;
            while (Exam_3 < 0.0 || Exam_3 > 100.0)
            {
                Console.Write("Exam score cannot be less than 0.0 or greater than 100.0. Please re-enter the score for Exam 3 <Example: 95.0>:");
                Exam_3 = Convert.ToDouble(Console.ReadLine());
                ++errorCount;
                ErrorCount(errorCount);
            }
            Console.WriteLine(" ");
            Console.Write("Please enter score for Assignment 1 <Example: 100.0>: ");
            Assignment_1 = Convert.ToDouble(Console.ReadLine());
            errorCount = 0;
            while (Assignment_1 < 0.0 || Exam_2 > 100.0)
            {
                Console.Write("Assignment score cannot be less than 0.0 or greater than 100.0. Please re-enter the score for Assignment 1 <Example: 95.0>:");
                Assignment_1 = Convert.ToDouble(Console.ReadLine());
                ++errorCount;
                ErrorCount(errorCount);
            }
            Console.Write("Please enter score for Assignment 2 <Example: 23.46>: ");
            Assignment_2 = Convert.ToDouble(Console.ReadLine());
            errorCount = 0;
            while (Assignment_2 < 0.0 || Assignment_2 > 100.0)
            {
                Console.Write("Assignment score can not be less than 0.0 or greater than 100.0. Please re-enter the score for Assignment 2 <Example: 56.0>: ");
                Assignment_2 = Convert.ToDouble(Console.ReadLine());
                ++errorCount;
                ErrorCount(errorCount);
            }
            Console.WriteLine(" ");
            Console.WriteLine(" -------------- OUTPUT ---------------");
            Console.WriteLine(" ");
            Console.Write("Student: ");
            Console.WriteLine(First + Last);
            Console.WriteLine(" ");
            Console.Write("Press any key to continue . . . ");
            Console.ReadLine();
        }
        public static void ErrorCount(int errorCount)
        {
            if (errorCount > 0)
            {
                Console.Write("Error count too much ! . . . ");
                Console.Write("Press any key to exit . . . ");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
