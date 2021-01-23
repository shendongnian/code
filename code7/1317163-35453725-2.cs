    Task _task = Task.Run(() => { }); // Task.CompletedTask in 4.6
    int _id;
    double _value;
    public double Value
    {
        get { return _value; }
        set
        {
            _value = value;
            OnPropertyChanged();
            // task
            _id++;
            var id = _id;
            _task = _task.ContinueWith(o =>
            {
                if (_id == id)
                {
                    Thread.Sleep(1000); // simulate work
                    if (_id == id)
                    {
                        _value = value;
                        Dispatcher.InvokeAsync(() => OnPropertyChanged(nameof(Value)));
                    }
                }
            });
        }
    }
