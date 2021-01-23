    public Data.MeetingInfo.Meeting Meeting
    {
        get { return _Meeting; }
        set
        {
            // Has the existing meeting object changed at all?
            if(_Meeting != null && _Meeting.IsDirty)
            {
                // Yes, so save it
                _Model.Serialize();
                _Meeting.MarkClean();
            }
            // Now we can update to new value
            if (value != null)
            {
                _Meeting = value;
                OnPropertyChanged("Meeting");
            }
        }
    }
    private Data.MeetingInfo.Meeting _Meeting;
