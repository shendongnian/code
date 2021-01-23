    DateTime target = new DateTime(2016, 5, 8, 11, 35, 0);
    const double interval60Minutes = 1000; // milliseconds to one hour
    System.Timers.Timer checkForTime = new System.Timers.Timer(interval60Minutes);
    private void Form1_Load(object sender, EventArgs e)
       {
            checkForTime.Elapsed += new ElapsedEventHandler(checkForTime_Elapsed);
            checkForTime.Enabled = true;
       }
    void checkForTime_Elapsed(object sender, ElapsedEventArgs e)
        {
            DateTime now = DateTime.Now;
            if (target.ToString("HH:mm:ss") == now.ToString("HH:mm:ss"))
            {
               MessageBox.Show("It's Time");
            }
        }
    }
