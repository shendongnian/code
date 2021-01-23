    public class Logger:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged
    	private string _Description;
    	public static readonly PropertyChangedEventArgs DescriptionProperty = new PropertyChangedEventArgs(nameof(Description));
    
    	public string Description
    	{
    		get { return _Description; }
    		set
    		{
    			_Description = value;
    			PropertyChanged?.Involke(this, DescriptionProperty);
    		}
    	}
    }
