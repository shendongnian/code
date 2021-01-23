    void Main()
    {
        var s = new Scary();
        s.Test();
    }
    
    public class Scary
    {
        public Scary()
        {
            Console.WriteLine(".ctor");
        }
        
        ~Scary()
        {
            Console.WriteLine("finalizer");
        }
        
        public void Test()
        {
            Console.WriteLine("starting test");
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            Console.WriteLine("ending test");
        }
    }
