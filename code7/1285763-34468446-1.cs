    // This ensures only the exact one milliseconds are used and not recalculated with other calls to DateTime.Now;
    DateTime NewTime = DateTime.Now;
    TimeSpan ElapsedTime = NewTime - _LastLogTime;
    _LastLogTime = NewTime;
    
    string LogMessage = string.Format("{0,7:###.000}", ElapsedTime.TotalSeconds);
