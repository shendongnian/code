    class Program
    {
        static Timer timer;
        static void Main(string[] args)
        {
            //set timer interval of 3 seconds
            timer = new Timer(interval: 3000);
            timer.Elapsed += Timer_Elapsed;
            InterruptPort sensor = new InterruptPort(/* sensor port information */);
            sensor.OnInterrupt += new NativeEventHandler(sensor_OnInterrupt);
        }
        private static void sensor_OnInterrupt(uint data1,uint data2,DateTime time)
        {
            Console.WriteLine(DateTime.Now);
            timer.Enabled = true;
        }
        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine(DateTime.Now); 
            timer.Enabled = false;
            //do work
        }
    }
