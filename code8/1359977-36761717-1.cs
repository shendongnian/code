    private void Initialize()
    {
        //If the query is not set yet we can't do it
        if (null == query)
            throw new InvalidOperationException();
           //If we're not connected yet, this is the time to do it...
         lock (this)
        {
            if (null == scope)
                scope = ManagementScope._Clone(null);
        }
          lock (scope)
        {
            if (!scope.IsConnected)
                scope.Initialize();
        }
    }
