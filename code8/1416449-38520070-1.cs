    private void Method()
    {
        if(!_executed)
        {
            _executed = true;
            // ...
        }
    }
    private void Method()
    {
        myButton.Enabled = false;
        // ...
    }
    private void Method()
    {
        // Prevent concurrent access
        lock(lockObj)
        {
            if(!_executed)
            {
                _executed = true;
                // ...
            }
        }
    }
