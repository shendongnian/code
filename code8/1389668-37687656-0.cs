    public DateTime StartDateTime 
    { 
        get 
        { 
            return StartDate.Add(StartTime.TimeOfDay); 
        } 
    } 
now, when StartTime is updated or StartDate is updated you want those changes to be reflected in the UI for example. To trigger that you need the call to RaisePropertyChanged(() => StartDateTime);
    private DateTime _startTime;
    public DateTime StartTime
    {
       get { return _startTime; }
       set
       {
           _startTime = value;
           RaisePropertyChanged(() => StartDateTime);
        }
    }
