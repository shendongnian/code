    public class MyViewModel : INotifyPropertyChanged
    {
    	// INotifyPropertyChanged gubbins
    	public MyViewModel()
    	{
            this._myObjects.CollectionChanged += (o, e) =>
    		{
    			if (e.NewItems != null)
    			{
    				foreach (var obj in e.NewItems.OfType<MyObject>())
    				{
    					obj.PropertyChanged += this.OnIsSelectedChanged;
    				}
    			}
    
    			if (e.OldItems != null)
    			{
    				foreach (var obj in e.OldItems.OfType<MyObject>())
    				{
    					obj.PropertyChanged -= this.OnIsSelectedChanged;
    				}
    			}
                if (e.PropertyName == "IsSelected")
    		    {
    			    this.CanDoSomething = this.MyObjects.Any(x => x.IsSelected);
    		    }
    		};
    	}
    	
        private readonly ObservableCollection<MyObject> _myObjects =
    		 new ObservableCollection<MyObject>();
        public ObservableCollection<MyObject> MyObjects
        {
            get
            {
                return _myObjects;
            }
        }
    
    	private void OnIsSelectedChanged(object o, PropertyChangedEventArgs e)
    	{
    		if (e.PropertyName == "IsSelected")
    		{
    			this.CanDoSomething = this.MyObjects.Any(x => x.IsSelected);
    		}
    	}
    
    	private bool _canDoSomething;
        public bool CanDoSomething
    	{
    		get { return this._canDoSomething; }
    		private set
    		{
    			if (_canDoSomething != value)
    			{
    				_canDoSomething = value;
    				OnPropertyChanged("CanDoSomething");
    			}
    		}
    	}
    }
