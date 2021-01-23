    [SyncVar(hook = "OnSomeValueChange")]
    public bool isMeshEnabled;
        
    public void OnSomeValueChange(bool valueToChangeTo)
    {
         isMeshEnabled = valueToChangeTo;
         // Enable/Disable client's mesh here
    }
