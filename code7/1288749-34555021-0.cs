    public static void Main (string[] args)
    {
        // Note: This crashes if non numeric characters are entered!
        Console.WriteLine ("Please enter 3 numbers:");
        int num1 = Convert.ToInt32(Console.ReadLine());
        int num2 = Convert.ToInt32(Console.ReadLine());
        int divisor = Convert.ToInt32(Console.ReadLine());
        // Find the lowest and highest in case they are entered in the wrong order
        int lowerNum = Math.Min(num1, num2); 
        int upperNum = Math.Max(num1, num2); 
        // Find the first factor over the lower bound
        // E.g. for a = 10, b = 20, c = 3, we have remainder = 1
        //      = 10 + (3 - 1)
        //      = 12
        int remainder = lowerNum % divisor;
        int factor = (remainder == 0)
          ? lowerNum 
          : lowerNum + (divisor - remainder);
        // Calculate all other factors up to the upper bound by simple addition
        while(factor <= upperNum){
          Console.WriteLine(factor);
          factor += divisor;
        }
    }
