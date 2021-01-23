    public class ViewModel : INotifyPropertyChanged {
    private string luminRecevied;
    public string LuminRecevied
    {
        get { return luminRecevied; }
        set
        {
            if (this.luminRecevied == value)
            {
                return;
            }
            this.luminRecevied = value;
            this.InvokePropertyChanged("LuminRecevied");
        }
    }
    private void InvokePropertyChanged(string propName)
    {
        var propertyChanged = PropertyChanged;
        if (propertyChanged != null)
            this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propName));
    }
    public event PropertyChangedEventHandler PropertyChanged;
    }
