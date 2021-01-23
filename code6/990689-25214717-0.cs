    int _dayOfWeek;
    public int dayOfWeek
        {
            get
            {
                return _dayOfWeek;
            }
            set
            {
                if (value > 0 && value < 8) _dayOfWeek = value;
            }
        }
