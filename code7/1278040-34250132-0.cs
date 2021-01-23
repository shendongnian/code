    public class ViewModel : INotifyPropertyChanged
    {
    public event PropertyChangedEventHandler PropertyChanged;
    private string _logBox ;
    public string LogBox 
    { 
    get
    {
    return _logBox;
    }
    set
    {
    if(value!=_logBox)
    {
     _logBox=value;
    OnPropertyChanged("LogBox");
    
    }
    }
    protected void OnPropertyChanged(string name)
    {
    PropertyChangedEventHandler handler = PropertyChanged;
    if (handler != null)
    {
    handler(this, new PropertyChangedEventArgs(name));
    }
    }
    }
