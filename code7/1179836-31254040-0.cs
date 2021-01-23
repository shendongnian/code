    static void Main(string[] args)
    {
        Console.WriteLine("enter the amount of numbers you would like to find the average and mean of: ");
        int arraylength = Int32.Parse(Console.ReadLine());
        int[] AverageArray = new int[arraylength];
        //filling the array with user input
        for (int i = 0; i < arraylength; i++)
        {
            Console.Write("enter the numbers you wish to find the average for: ");
            AverageArray[i] = Int32.Parse(Console.ReadLine());
        }
        //printing out the array 
        Console.WriteLine("here is your array: ");
        for (int i = 0; i < arrayLength; i++)
        {
            Console.WriteLine(AverageArray[i]);
        }
        Console.WriteLine(FindAverage(AverageArray));
    }
    public static double FindAverage(int[] averageNumbers)
    {
        double arraySum = 0;
        for (int i = 0; i < averageNumbers.Length; i++)
            arraySum += averageNumbers[i];
        // cast to 'double' otherwise you will lose precision
        return arraySum / (double)averageNumbers.Length;
    }
