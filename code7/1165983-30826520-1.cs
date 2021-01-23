    class SimpleClass
    {
        public bool Flag { get; set; }
    
        public void function()
        {
            Flag = false;
            var timer = new System.Timers.Timer(1000);
            timer.Elapsed += (src, args) => { Flag = true; Console.WriteLine("I'm done"); };
            timer.AutoReset = false;
            timer.Start();
        }
    }
