    public class Counter : INotifyPropertyChanged
    {
    	HashSet<DependencyObject> _hash = new HashSet<DependencyObject>();
    
    	public void Add(DependencyObject obj)
    	{
    		this._hash.Add(obj);
    		this.RaisePropertyChanged("Count");
    	}
    
    	public void Remove(DependencyObject obj)
    	{
    		this._hash.Remove(obj);
    		this.RaisePropertyChanged("Count");
    	}
    
    	public int Count
    	{
    		get
    		{
    			return this._hash.Count;
    		}
    	}
    
    	// INotifyPropertyChanged implementation omitted...
    }
