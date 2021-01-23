            this.regularTimer.Interval = 5000; //Convert.ToDouble(ConfigurationManager.AppSettings["RegularTimer"]);
        
            this.longTimer.Interval = 10000; //_scheduleTime.Subtract(DateTime.Now).TotalSeconds * 1000;
                        
    Then Put a BreakPoint in `DoRegular` method and another in `DoLongRunning` method and run application in Debug Mode
