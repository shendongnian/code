    // This ensures only the exact one Tick is used for subsequent calculations
    // Instead of calling DateTime.Now again and getting different values
    DateTime NewTime = DateTime.Now;
    TimeSpan ElapsedTime = NewTime - _LastLogTime;
    _LastLogTime = NewTime;
    
    string LogMessage = string.Format("{0,7:###.000}", ElapsedTime.TotalSeconds);
