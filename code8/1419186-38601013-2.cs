    double result;
    double a, b;
    
    a = GetValue("Enter value for a ");
    b = GetValue("Enter value for b ");
    result = a + b;
    
    public static double GetValue(string input )
    {
        double value;
        Console.WriteLine(input);
    
        while (!Double.TryParse(Console.ReadLine(), out value)) 
        {
            Console.WriteLine("invalid value please try again..");
        }
    
    	return value;
    }
