    public partial class StatusElement : UserControl,INotifyPropertyChanged
    {
     ....
    public event PropertyChangedEventHandler PropertyChanged;
    private void RefreshState([CallerMemberName]string prop = "")
    {
        switch (State)
        {
            case "":
                MyImage.Visibility = Visibility.Hidden;
                break;
            default:
                MyImage.Visibility = Visibility.Visible;
                break;
        }
        statusLabel.Content = State;
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
    } 
