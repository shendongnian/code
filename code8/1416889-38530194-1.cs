    public void Main()
    {
        var closure = new Main_Closure();
        closure.h = new HelloWorld() { Name = "A" };
        Task.Factory.StartNew(closure.M1);
        closure.h = new HelloWorld() { Name = "B" };
    }
    class Main_Closure
    {
        public HelloWorld h;
        public void M1()
        {
            Console.WriteLine(h.Name); 
        }
    }
