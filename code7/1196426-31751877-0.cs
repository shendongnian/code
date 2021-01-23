    string startTime = teststart.Text;
    string finishTime = testfinish.Text;
    string lunchTime = testlunch.Text;
    string subtract = subtract.Text;
    
    TimeSpan duration = DateTime.Parse(finishTime).Subtract(DateTime.Parse(startTime)).
        Subtract(TimeSpan.FromMinutes(Int32.Parse(subtract)));
