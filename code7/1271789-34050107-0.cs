     string input;
     decimal factor1;
    
     Dictionary<string, decimal> factors = new Dictionary<string, decimal>();
    
     factors.Add("1", one);
     factors.Add("2", two);
     factors.Add("3", three);
     factors.Add("4", four);
     factors.Add("5", five);
    
     input = Console.ReadLine();
    
     if (factors.ContainsKey(input))
     {
        factor1 = factors["input"];
     }
