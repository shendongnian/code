    DateTime timerView = DateTime.Now;
    DateTime timerTest = timerView;
    
    if(robHour.Checked == true)
        timerTest = timerView.Add(new TimeSpan(0, 1, 0, 0));
    else if(robDay.Checked == true)
        timerTest = timerView.Add(new TimeSpan(1, 0, 0, 0));
    
    txbTimer.Text = timerTest.Day + 
                   "/" + timerTest.Month + "/" + 
                   timerTest.Year + " " + timerTest.Hour + 
                   ":" +  timerTest.Minute.ToString("D2");
