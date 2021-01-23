    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            WaitCounter counter = new WaitCounter();
            A[] arr = new A[10];
            for (int i = 0; i < arr.Length; i++)
                arr[i] = new A(r.Next(2000, 5000), counter);
            for (int i = 0; i < arr.Length; i++)
                new Thread(arr[i].SomeFunc).Start();
            while (counter.Counter < 5)
            {
                counter.Wait();
            }
            Console.WriteLine("{0} threads called set", counter.Counter);
            Thread.Sleep(7000);
            Console.WriteLine("{0} threads called set", counter.Counter);
        }
    }
    class A
    {
        private static int ID = 1;
        private static readonly Stopwatch sw = Stopwatch.StartNew();
        private readonly int id;
        private readonly int duration;
        private readonly WaitCounter counter;
        public A(int duration, WaitCounter counter)
        {
            id = ID++;
            this.duration = duration;
            this.counter = counter;
        }
        public void SomeFunc(object o)
        {
            Thread.Sleep(duration);
            counter.Increment();
            Console.WriteLine(
                @"{0}-{1} incremented counter! Elapsed time: {2:mm\:ss\.fff}",
                GetType().Name, id, sw.Elapsed);
        }
    }
    class WaitCounter
    {
        private readonly AutoResetEvent _event = new AutoResetEvent(false);
        private int _counter;
        public int Counter { get { return _counter; } }
        public void Increment()
        {
            Interlocked.Increment(ref _counter);
            _event.Set();
        }
        public void Wait()
        {
            _event.WaitOne();
        }
    }
