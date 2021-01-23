    static void Main(string[] args)
        {
            Int32 pointsEarned;
            string firstName;
            string lastName;
            Int32 percentageGrade;
            Console.WriteLine("Enter the student's first name.");
            firstName = Console.ReadLine();
            Console.WriteLine("Enter the student's last name.");
            lastName = Console.ReadLine();
            Console.WriteLine("Enter the amount of points earned.");
            pointsEarned = int.Parse(Console.ReadLine());
            percentageGrade = pointsEarned / 1000;
            if (percentageGrade <=100 && percentageGrade>= 90)
            {
                string finalGrade = "A";
            }
            else if (percentageGrade <=89 && percentageGrade>= 80 )
            {
                string finalGrade = "B";
            }
            else if (percentageGrade <= 79 && percentageGrade>= 70)
            {
                string finalGrade = "C";
            }
            else if (percentageGrade <= 69 && percentageGrade>= 60)
            {
                string finalGrade = "D";
            }
            else if (percentageGrade <= 59 && percentageGrade >= 0)
            {
                string finalGrade = "F";
            }
    
    
        }
