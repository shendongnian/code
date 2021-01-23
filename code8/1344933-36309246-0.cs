    public class A
    {
        int i;
        public object SyncObject
        {  get; private set; }
        public A()
        {
            SyncObject = new object();
            i = 0;
        }
        protected void RunLoop()
        {
            while (i < 100)
            {
                i++;
            }
            lock (SyncObject)
            {
                Monitor.Pulse(SyncObject);
            }
        }
        public void Start()
        {
            var runThread = new Thread(new ThreadStart(RunLoop));
            runThread.Start();
        }
        public void PrintI()
        {
            Console.WriteLine("I == " + i);
        }
    }
    public class B
    {
        public static void Run()
        {
            A classAInstance = new A();
            classAInstance.Start();
            lock (classAInstance.SyncObject)
                Monitor.Wait(classAInstance.SyncObject);
            classAInstance.PrintI();
        }
    }
