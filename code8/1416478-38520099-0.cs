    static void Main(string[] args)
    {
        int x = 5;
        int y = 4 + 1;
    
        Method1(x);
        Method2(y);
    }
    
    private static void Method1(int lockObject1)
    {
        lock (lockObject1)
        {
    
        }
    }
    
    private static void Method2(int lockObject2)
    {
        lock (lockObject2)
        {
    
        }
    }
