    public sealed class GItemViewModel : INotifyPropertyChanged
    {
        private string _name = string.Empty;
     	public string Name
    	{
    		get { return _name; }
    		set { _name = value; NotifyPropertyChanged( "Name" ); }
    	}
        public ObservableCollection<GItemViewModel> Nodes { get; private set; }
        ...
    }
