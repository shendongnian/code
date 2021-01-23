    public interface INotifyErrorObject : INotifyPropertyChanged, IDataErrorInfo
    {
          void SetError(string propertyName, string error);
          void ClearErrors();
    }
    public class EntityBaseBase : INotifyErrorObject
    {
      Dictionary<string, string> validationErrors;
    public void SetError(string propName, string error)
    { 
        string obj=null;
        if (validationErrors.TryGetValue(propName, out obj))
        {
            if (string.IsNullOrEmpty(error)) //Remove error
                validationErrors.Remove(propName);
            else if (string.CompareOrdinal(error, obj) == 0) //if error is same as previous return
                return;
            else
                validationErrors[propName] = error; //set error
        }
        else if (!string.IsNullOrEmpty(error))
            validationErrors.Add(propName, error);
        
        RaisePropertyChanged(propName);
    }
    public void ClearErrors()
    {
        var properties = validationErrors.Select(s => s.Value).ToList();
        validationErrors.Clear();
        
        //Raise property changed to reflect on UI
        foreach (var item in properties)
        {
            RaisePropertyChanged(item);
        }
    }
    public EntityBaseBase()
    {
        validationErrors = new Dictionary<string, string>();
    }  
    public event PropertyChangedEventHandler PropertyChanged;
    protected void RaisePropertyChanged(string propName)
    {
        if (PropertyChanged != null && !string.IsNullOrEmpty(propName))
            PropertyChanged(this, new PropertyChangedEventArgs(propName));
    }
    public string Error
    {
        get { throw new NotImplementedException(); }
    }
    public string this[string columnName]
    {
        get 
        {
            string obj=null;
            if (validationErrors.TryGetValue(columnName, out obj))
                return obj;
            else
                return null;
        }
    }
    }
