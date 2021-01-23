    static void PrintSlowly(string print)
    {
        int index = 0;
        System.Timers.Timer timer = new System.Timers.Timer();
        timer.Interval = 100;
        timer.Elapsed += new System.Timers.ElapsedEventHandler((sender, args) =>
        {
            if (index < print.Length)
            {
                Console.Write(print[index]);
                index++;
            }
            else
            {
                Console.Write("\n");
                timer.Enabled = false;
            }
        });
        timer.Enabled = true;
    }
