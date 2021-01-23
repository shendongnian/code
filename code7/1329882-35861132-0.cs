    public int NumSelect()
    {
        string line = Console.ReadLine();
        return int.Parse(line);
    }
    static void Main()
    {
        SimpleMath operation = new SimpleMath();
        Console.WriteLine("Give me two numbers and I will add them");
        int number1 = operation.NumSelect();
        int number2 = operation.NumSelect();
        int result = operation.Add(number1, number2);
        Console.WriteLine("{0} + {1} = {2}", number1, number2, result);
    }
