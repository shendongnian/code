     class Program
    {
        static void Main(string[] args)
        { 
            Timer t = new System.Timers.Timer(1000);
            t.Elapsed += Hitme;
            t.Start();
            Console.ReadLine();
        }
        private static void Hitme(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Ouch");
        }
    }
