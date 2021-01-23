    public class StringMember : INotifyPropertyChanged
    {
    private string m_actualString;
    public string Text
    {
        get { return m_actualString; }
        set
        {
            m_actualString = value;
            //OnPropertyChanged("Text");
            //OnPropertyChanged("Length");
        }
    }
    public int Length { get { return Value.Length; } }
    //public event PropertyChangedEventHandler PropertyChanged;        
    //protected virtual void OnPropertyChanged(string propertyName = null)
    //{
    //    PropertyChangedEventHandler handler = PropertyChanged;
    //    if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
    //}
