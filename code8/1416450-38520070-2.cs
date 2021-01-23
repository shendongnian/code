    private bool _executed = false;
    private void Method()
    {
        if(!_executed)
        {
            _executed = true;
            // ...
        }
    }
    private readonly Button _button = new Button();
    private void Method()
    {
        _button.Enabled = false;
        // ...
    }
    private readonly object _lockObj = new object();
    private void Method()
    {
        // Prevent concurrent access
        lock(_lockObj)
        {
            if(!_executed)
            {
                _executed = true;
                // ...
            }
        }
    }
