    try
    {
        Console.WriteLine("enter a");
        string a = Console.ReadLine();
        
        Console.WriteLine("enter b");
        string b = Console.ReadLine();
    
        a=int.parse(a);
        b=int.parse(b);
    
    
        
        Program e = new Program();
        
        int sum= e.sum( a, b);
        Console.WriteLine("sum is " + sum);
        
        
        public int sum(int a, int b)
        {
        
           int sum = a + b;
           return sum;
        
        }
    }
    catch(FormatException e){Console.WriteLine("Wrong input");}
