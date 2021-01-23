    double _value;
    public double Value
    {
        get { return _value; }
        set
        {
            _value = Task.Run(() =>
            {
                var temp = value;
                Thread.Sleep(100);
                return temp;
            }.Result;
            OnPropertyChanged();
        }
    }
    // bonus
    public void OnPropertyChanged([CallerMemberName] string property = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
