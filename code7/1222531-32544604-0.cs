    public class PC
    {
        const int THREADS = 5;
        static BlockingCollection<string> _Collection = new BlockingCollection<string>();
        public PC()
        {
            //1 producer  
            Task.Run(()=>Producer());
            //N consumer
            for (int i = 0; i < THREADS; i++) Task.Run(() => Consumer());
        }
        void Producer()
        {
            Random rnd = new Random();
            while(true)
            {
                Thread.Sleep(100);
                _Collection.Add(rnd.Next().ToString());
            }
        }
        void Consumer()
        {
            while(true)
            {
                string str = _Collection.Take();
                Console.WriteLine("Thread \"{0}\" consumed {1}", Thread.CurrentThread.ManagedThreadId, str);
            }
        }
    }
