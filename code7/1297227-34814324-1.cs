    public class MyViewModel
    {
    	private CollectionView _items;
    	private Visibility _windowVisibility;
    	
    	public MyViewModel() 
    	{
    		_items = new CollectionView();
    		_items.CollectionChanged += HandleCollectionChanged;
    	}
    	
    	public Visibility WindowVisibility
    	{
    		get { return _windowVisibility; }
    		set 
    		{
    			_windowVisibility = value;
    			NotifyPropertyChanged();
    		}
    	}
    	
    	private void HandleCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
    	{
            if (((IEnumerable)value).GetEnumerator().MoveNext())
                WindowVisibility = Visibility.Visible;
            else 
                WindowVisibility = Visibility.Hidden;
    	}
    
    }
