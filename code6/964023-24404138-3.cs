    public int number
    {
        get { return _number; }
        set
        {
            _number = value;
            RaisePropertyChanged("number");
        }
    }
    public void change(bool up)
    {
        if (up)
            number++;
        else
            number--;
    }
