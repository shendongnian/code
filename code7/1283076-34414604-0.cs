    public class BuddyChatViewModel : INotifyPropertyChanged, BaseViewModel
    {
    private string chat;
    public string Chat
    {
        get { return chat; }
        set
        {
            chat = value;
            NotifyPropertyChanged("Chat");
        }
    }   
    
    //INotifyPropertyChanged Members
    public event PropertyChangedEventHandler PropertyChanged;
    private void NotifyPropertyChanged(String info)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(info));
        }
    }
    }
