    static void Main(string[] args)
    {
        float value1, value2, value3, average;
    
        Console.WriteLine("--Welcome to the Avarge Calculator--");
        Console.ReadLine();
    
        Console.WriteLine("Please Enter The First Number: ");
        value1 = float.Parse(Console.ReadLine());
    
        Console.WriteLine("Please Enter The Secound Number: ");
        value2 = float.Parse(Console.ReadLine());
    
        Console.WriteLine("Please Enter The Third Number: ");
        value3 = float.Parse(Console.ReadLine());
    
        average = Program.MeanAverageOfThree(value1, value2, value3);
    
        Console.WriteLine("The Greatest Common Divisor of {0} and {1} and {2} is: {3} ", value1, value2, value3, average);
        Console.ReadLine();
    }
    public static float MeanAverageOfThree(float value1, float value2, float value3) 
    {
        return (value1 % 3 + value2 % 3 + value3 % 3 + 6) / 3 - 2 + (value1 / 3 + value2 / 3 + value3 / 3);
    }
