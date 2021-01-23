    public DateTime Date
    {
        get { return _date; }
        set
        {
            if (value [is _not_in_range_])
                throw new Exception("Value is not in range");
            _date = value;
        }
    }
