    public void AddValidationError(string errorString, [CallerMemberName] string propertyName = null)
    {
        _notifyvalidationErrors[propertyName] = new List<string>{ errorString };
        RaiseErrorsChanged(propertyName);
    }
     
    public void ClearValidationError([CallerMemberName] string propertyName = null)
    {
        if (_notifyvalidationErrors.ContainsKey(propertyName))
        {
            _notifyvalidationErrors.Remove(propertyName);
            RaiseErrorsChanged(propertyName);
        }
    }
