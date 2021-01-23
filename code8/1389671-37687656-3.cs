    private DateTime _startTime;
    public DateTime StartTime
    {
       get { return _startTime; }
       set
       {
           _startTime = value;
           StartDateTime = StartDate.Add(_startTime.TimeOfDay)
       }
    }
    private DateTime _startDate;
    public DateTime StartDate
    {
       get { return _startDate; }
       set
       {
           _startDate = value;
           StartDateTime = _startDate.Add(StartTime.TimeOfDay)
       }
    }
    private DateTime _startDateTime;
    public DateTime StartDateTime
    {
        get { return _startDateTime; }
        set
        {
           _startDateTime = value;
           RaisePropertyChanged(() => StartDateTime);
        }
    }
Since a modification to either StartDate or StartTime will set StartDateTime, which in turn will call RaisePropertyChanged for itself so the UI can reflect the changes as well.
