    public bool HasErrors
    {
        get { return _notifyvalidationErrors.Any(kv => kv.Value != null); }
    }
    public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
         
    public void RaiseErrorsChanged(string propertyName)
    {
           var handler = ErrorsChanged;
           if (handler != null)
               handler(this, new DataErrorsChangedEventArgs(propertyName));
    }
    public IEnumerable GetErrors(string propertyName)
    {
        List<string> errorsForProperty;
        _notifyvalidationErrors.TryGetValue(propertyName, out errorsForProperty);
         
        return errorsForProperty;
    }
