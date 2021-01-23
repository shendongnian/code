    TimeSpan start = new TimeSpan(4, 0, 0); //4 o'clock
    TimeSpan end = new TimeSpan(12, 0, 0); //12 o'clock
    TimeSpan now = DateTime.Now.TimeOfDay;
    
    if ((now > start) && (now < end))
    {
        MessageBox.Show("time is between 12am and 4am");
    }
