    public static Queue<int> Results = new Queue<int>(); 
    
    public static void Add(int a, int b) { Results.Enqueue(a + b); }
    public static void Sub(int a, int b) { Results.Enqueue(a - b); }
    
    public delegate void MyDel(int a, int b);
    
    public static void Meth_del()
    {
        int x, y;
        MyDel _delegate;
        _delegate = Add;
        _delegate += Sub;
        _delegate(5, 4);
        while (Results.Any()) 
            Console.WriteLine(Results.Dequeue());
    }
