    static void Main(String[] args)
        {
            Timer MyTimer = new Timer();
            MyTimer.Interval = 2000;
            MyTimer.Enabled = true;
            MyTimer.Elapsed += new ElapsedEventHandler(myTimer_Elapsed);
            MyTimer.Start();
            Console.ReadLine();
        }
    
        private static void myTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("You're alive!");
    
        }
