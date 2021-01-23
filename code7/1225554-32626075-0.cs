    static void Main(string[] args)
    {
    
        int five = 5;
        int sum = 0;
    
        for (int i = 0;   i < 1000; i++){
    
            if (i % five == 0)
            {
                sum += i;
            }
    
        }
        
        Console.WriteLine(sum);
    }
