    public class Signal: INotifyPropertyChanged 
    {
    	public string Name 
    	{
    		get;
    		set;
    	}
    	public Int32 Value 
    	{
    		get;
    		set;
    	}
    	private ObservableCollection < RawVal > rawValue1;
    	public ObservableCollection < RawVal > rawValue 
    	{
    		get 
    		{
    			return rawValue1;
    		}
    		set 
    		{
    			rawValue1 = value;
    			OnPropertyChanged("rawValue");
    			if (value != null && value.Count > 0) 
    			{
    				SelectedRaValue = value.First();
    			}
    		}
    	}
    
    	private RawVal selectedRaValue;
    	public RawVal SelectedRaValue 
    	{
    		get 
    		{
    			return selectedRaValue;
    		}
    		set 
    		{
    			selectedRaValue = value;
    			OnPropertyChanged("SelectedRaValue");
    			ComboValue = value.name;
    			OnPropertyChanged("ComboValue");
    		}
    	}
    
    	public string ComboValue 
    	{
    		get;
    		set;
    	}
    
    	#region Implementation of INotifyPropertyChanged
    
    	public event PropertyChangedEventHandler PropertyChanged;
    	
    	protected virtual void OnPropertyChanged(string propertyName) 
    	{
    		PropertyChangedEventHandler handler = PropertyChanged;
    		if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
    	}
    
    	#endregion
    }
