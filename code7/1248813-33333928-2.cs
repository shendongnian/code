    private bool _isRunning = false;
    private void SelectedIndexChange(...)
    {
        if(_isRunning) return;
        _isRunning = true;
        try
        {
            // do your things
        }
        finally
        { 
            _isRunning = false;
        }
    }
