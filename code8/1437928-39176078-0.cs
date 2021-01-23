        public static void Start()
        {
            for(DateTime later = DateTime.Now.AddSeconds(5); DateTime.Now < later; Thread.Sleep(500))
            {
                Console.WriteLine("Other Thread: " + DateTime.Now.ToLongTimeString());
            }
        }
        
        public static void Main(string[] args)
        {
            Thread thread = new Thread(Start);
            thread.Start(); 
        }
