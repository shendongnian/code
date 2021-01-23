      TimeSpan start = new TimeSpan(00, 0, 0); //12  o'clock am
      TimeSpan end = new TimeSpan(04, 0, 0); //4 o'clock am
      TimeSpan now = DateTime.Now.TimeOfDay;
      if ((now > start) && (now < end))
      {
         MessageBox.Show("time is between 12am and 4am");
       }
