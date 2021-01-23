    var dt = DateTime.Now;
    if (dt.TimeOfDay <= new TimeSpan(11, 59, 0))
    {
       MessageBox.Show("Good Morning");
    }
    else if (dt.TimeOfDay >= new TimeSpan(12, 0, 0) && dt.TimeOfDay < new TimeSpan(16, 59, 0))
    {
       MessageBox.Show("Good Afternoon");
    }
    else if (dt.TimeOfDay >= new TimeSpan(17, 0, 0))
    {
       MessageBox.Show("Good Evening");
    }
