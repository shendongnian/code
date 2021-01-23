    if (newElement != null)
    			{
    				newElement.PropertyChanging += ElementPropertyChanging;
    				newElement.PropertyChanged += ElementPropertyChanged;
    				if (newElement.ItemsSource is INotifyCollectionChanged)
    					(newElement.ItemsSource as INotifyCollectionChanged).CollectionChanged += DataCollectionChanged;
    			}
    protected virtual void ElementPropertyChanged(object sender, PropertyChangedEventArgs e)
    		{
    			if (e.PropertyName == "ItemsSource")
    			{
    				if (Element.ItemsSource is INotifyCollectionChanged)
    					(Element.ItemsSource as INotifyCollectionChanged).CollectionChanged += DataCollectionChanged;
    
    				context.RunOnUiThread (() => UpdateFromCollectionChange ());
    			}
    		}
