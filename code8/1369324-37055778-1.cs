    private TimeSpan _lengthOfTime = TimeSpan.MinValue;
    public TimeSpan LengthOfTime
    {
        get { return _lengthOfTime; }
        set
        {
            _lengthOfTime = value;
            OnPropertyChanged("LengthOfTimeString");
        }
    }
    public string LengthOfTimeString
    {
        get
        {
            if (LengthOfTime == TimeSpan.MinValue)
            {
                return "The length of time has not been set.";
            }
            else
            {
                return LengthOfTime.ToString("YourFavouriteStringFormatHere");
            }
        }
    }
