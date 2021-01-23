    public class MyData : INotifyPropertyChanged
    {
    private string myDataProperty;
    public MyData() { }
    public MyData(DateTime dateTime)
    {
        myDataProperty = "Last bound time was " + dateTime.ToLongTimeString();
    }
    public String MyDataProperty
    {
        get { return myDataProperty; }
        set
        {
            myDataProperty = value;
            OnPropertyChanged("MyDataProperty");
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged(string info)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(info));
        }
    }
