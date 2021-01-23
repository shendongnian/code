    using System;
    using System.Linq;
    class AV
    {
    public static void Main()
    {
        int[] averageGrades = new int[31];//Array to store    students
        int cntr;
        System.Random rnd = new System.Random();
        for (cntr = 0; cntr < 31; cntr++)
        {
            averageGrades[cntr] = rnd.Next(0, 101);
            Console.Write("Student {0}, Grade:    {1}", cntr, averageGrades[cntr]);
        }
        Console.WriteLine(GetAverage(averageGrades));
    }// End of main method
    private static double GetAverage(int[] averageGrade)
    {
        return averageGrade.Average(t => t);
        //calculate average here
    }// end of getLevel
    }// end of AV class
