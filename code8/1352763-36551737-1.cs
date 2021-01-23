    public class TestClass : INotifyPropertyChanged
    {
    private string _FName;
    public string FName
    {
        get { return _FName; }
        set { _FName = value; NotifyPropertyChanged("FName"); }
    }
    private string _SName;
    public string SName
    {
        get { return _SName; }
        set { _SName = value; NotifyPropertyChanged("FName"); }
    }
    private int _Age;
    public int Age
    {
        get { return _Age; }
        set { _Age = value; }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    private void NotifyPropertyChanged(String info)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(info));
        }
    }
    }
