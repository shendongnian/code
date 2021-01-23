    private readonly Dictionary<string, List<string>> _notifyvalidationErrors =
            new Dictionary<string, List<string>>();
    private readonly Dictionary<string, List<string>> _privateValidationErrors =
                new Dictionary<string, List<string>>();
    
    public void AddValidationErrorFromView(string propertyName, string errorString)
    {
       _notifyvalidationErrors[propertyName] = new List<string>();
       // Add the error to the private dictionary
       _privateValidationErrors[propertyName] = new List<string> {errorString};
       RaiseErrorsChanged(propertyName);
    }
     
     public void ClearValidationErrorFromView(string propertyName)
     {
         if (_notifyvalidationErrors.ContainsKey(propertyName))
         {
             _notifyvalidationErrors.Remove(propertyName);
         }
         if (_privateValidationErrors.ContainsKey(propertyName))
         {
             _privateValidationErrors.Remove(propertyName);
         }
         RaiseErrorsChanged(propertyName);
               
     }
    
