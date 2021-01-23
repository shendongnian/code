    using System;
    using System.Linq;
    class AV
    {
        public static void Main()
        {
            int[] averageGrades = new int[30];//Array to store    students
            int cntr;
            System.Random rnd = new System.Random();
            for (cntr = 0; cntr < averageGrades.Length; cntr++)
            {
                averageGrades[cntr] = rnd.Next(0, 101);
                Console.Write("Student {0}, Grade:    {1}", cntr, averageGrades[cntr]);
            }
            Console.WriteLine(GetAverage(averageGrades));
        }
        private static double GetAverage(int[] averageGrade)
        {
            return averageGrade.Average(t => t);
        }
    }
