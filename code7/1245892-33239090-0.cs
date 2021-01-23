    public static Form1 form = new Form1();
        public static bool run = true;
        [MTAThread]
        static void Main(string[] args)
        {
            new Thread(() => Application.Run(form)).Start();
            new Thread(work).Start();
        }
        public static void work()
        {
            while (run)
            {
                Console.WriteLine("Console Running");
            }
           
        }
