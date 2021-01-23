        public static DateTime StartTime { get; private set; } /* Usage: Program.StartTime */
        [STAThread]
        static void Main()
        {
            StartTime = DateTime.Now; 
            //...
        }
