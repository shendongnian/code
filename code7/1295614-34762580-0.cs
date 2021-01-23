    ObservableCollection<int> listOfObject = new ObservableCollection<int>() { 1, 2, 3, 4};
    
    listOfObject.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(
    	delegate (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    	{
    	if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
    		{
    			Console.WriteLine($"{e.NewItems[0]} just been added to the list at index = {e.NewStartingIndex}");
    		}
    		if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
    		{
    			Console.WriteLine($"Replace item {e.OldItems[0]} with {e.NewItems[0]}");
    		}
    	}
    );
    
    listOfObject.Add(1);
    listOfObject[2] = 3;
    listOfObject[3] = 1;
