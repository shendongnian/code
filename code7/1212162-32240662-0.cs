    static void Main(string[] args)
    {
        var intervalTime = new System.Timers.Timer();
        //D O   I T   H E R E
        intervalTime.Elapsed += new ElapsedEventHandler(intervalTime_Elapsed);
        intervalTime.Interval = 5000;
        intervalTime.Enabled = true;
        Console.WriteLine(intervalTime.Enabled.ToString());
        Console.WriteLine(intervalTime.Enabled.ToString());
        Console.ReadLine();
    }
    static void intervalTime_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        //Do something....
        Console.WriteLine("New event fired");
    }
