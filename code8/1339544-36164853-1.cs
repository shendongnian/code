    class Program 
    {
        private static Character Player;
        public static void Main(string[] args) 
        {
            Player = new Knight();
            timer.Elapsed += timer_Elapsed;
            timer.Start();            
            Console.Read();
        }
        private static void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Player.HP++;
            //Console.Clear();
            Console.WriteLine("=================================================");
            Console.WriteLine("");
            Console.WriteLine("                Health:  " + Player.HP);
            Console.WriteLine("");            Console.WriteLine("=================================================");
            if (i == 20)
            {
                timer.Stop();
            }
        }
    }
