public class MyViewModel : INotifyPropertyChanged
{
    #region INotifyPropertyChanged Members
    [field: NonSerialized]
    public event PropertyChangedEventHandler PropertyChanged = null;
    protected virtual void RaisePropertyChanged(string propName)
    {
        if(PropertyChanged != null)
        {
            Task.Run(() => PropertyChanged(this, new PropertyChangedEventArgs(propName)));
        }
    }
    #endregion
    public string TxtBox
    {
        get { return Model.TxtBoxValue; }
        set
        {
            Model.TxtBoxValue = value;
            RaisePropertyChanged("TxtBox");
        }
    }
    // presuming TxtBox2Value is in Model...else use a field
    public string TxtBox2
    {
        get { return Model.TxtBox2Value; }
        set
        {
            Model.TxtBox2Value = value;
            RaisePropertyChanged("TxtBox2");
        }
    }
    private ICommand _clickCommand;
    public ICommand ClickCommand
    {
        get
        {
            return _clickCommand ?? (_clickCommand = new CommandHandler(() => MyAction(), _canExecute)); // I believe that when the button is clicked MyAction() is triggered, right?
        }
    }
    private bool _canExecute = true;
    public void MyAction()
    {
        this.TxtBox2 = this.TxtBox; // should something like this work? Because right now it doesn't
    }
}
