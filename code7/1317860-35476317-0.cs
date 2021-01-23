    public class ViewModelBase : INotifyPropertyChanged
	{
	    public event PropertyChangedEventHandler PropertyChanged;
	    protected void OnPropertyChanged(string propertyName)
	    {
	        var handler = PropertyChanged;
	        if (handler != null)
	            handler(this, new PropertyChangedEventArgs(propertyName));
	    }
	}
