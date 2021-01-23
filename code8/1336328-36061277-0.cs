    public String DateInViewModel
    {
        get { return _dateInViewModel.ToString("MM/dd/yyyy hh:mm:ss"); }
        set
        {
            //You can use TryParseExact to avoid format error exception
            _dateInViewModel = DateTime.ParseExact(value, "MM/dd/yyyy hh:mm:ss", CultureInfo.InvariantCulture);
            OnPropertyChanged(new PropertyChangedEventArgs("DateInViewModel"));
        }
    }
