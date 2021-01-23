    using System;
    public class Week1
    {
    public static void Main(string[] args)
    {
        int variable1;
        int variable2;
        int variable3;
        //int[] arr = new int[2];
        //for (variable1 = 0; variable1 < 3; variable1++)
        //for (variable2 = 0; variable2 < 3; variable2++)
        //test
        
        int average;
        int sum;
        int remainder;
      
        Console.Write("Enter a number:");
        variable1 = Convert.ToInt32(Console.ReadLine());
        //arr[variable1] = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Enter another number:");
        variable2 = Convert.ToInt32(Console.ReadLine());
        //arr[variable2] = Convert.ToInt32(Console.ReadLine());
        Console.Write("one more:");
        variable3 = Convert.ToInt32(Console.ReadLine());
                sum = variable1 + variable2 + variable3;
                average = sum / 3;
                remainder = sum % 3;
        Console.WriteLine("The average of " + variable1
        + ", " + variable2 + ", " + variable3 + " is "
        + average + " with a remainder of " + remainder);
        //Console.WriteLine("THE remainder: {0}", remainder);
        //need spaces before quotes
        //Console.ReadLine();
    }
}
