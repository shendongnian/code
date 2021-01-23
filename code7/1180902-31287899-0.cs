    static void Main(string[] args)
            {
                System.Timers.Timer timer = new System.Timers.Timer(15000);
                timer.Elapsed += new System.Timers.ElapsedEventHandler(T_Elapsed);
                timer.Start();
                var i = Console.ReadLine();
               
            }
    
            static void T_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
            {
                Console.WriteLine("15");
                var T = (Timer)sender;
                T.Stop;
    
            }
