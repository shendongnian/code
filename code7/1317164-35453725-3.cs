    Task _task = Task.Run(() => { }); // Task.CompletedTask in 4.6
    volatile int _id;
    double _value;
    public double Value
    {
        get { return _value; }
        set
        {
            _value = value;
            OnPropertyChanged();
            // task
            var id = ++_id; // capture id
            _task = _task.ContinueWith(o =>
            {
                if (_id == id)
                {
                    Thread.Sleep(1000); // simulate work
                    // this is optional if value stays the same
                    if (_id == id)
                    {
                        _value = value + 10; // simulate different value
                        Dispatcher.InvokeAsync(() => OnPropertyChanged(nameof(Value)));
                    }
                }
            });
        }
    }
