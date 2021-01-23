    public class MyClass
    {
        static int nextId;
        public int id;
        public int x;
        public MyClass()
        {
            id = Interlocked.Increment(ref nextId);
            x = (id % 4 + 1) * 250; 
        }
        public void DoWork(CancelationToken cancelToken)
        {
            Console.Write("start: {0}", this.id);
            // changed a bit so you can see how to use the 
            // cancelation token.
            var cycle = 0;
            while (!cancelToken.IsCancellationRequested && cycle < 5)
            {
                Task.Delay(x / 5, cancelToken).Wait(); // don't do Thread.Sleep()
                cycle++;
            }               
            Console.WriteLine("end:  {0}", this.id);
        }
    }
