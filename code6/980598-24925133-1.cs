    using System.Collections.ObjectModel;
    
    ObservableCollection<string> myList;
    
    //The cnstructor 
    public MyClassname()
    {
      this.myList = new ObservableCollection<string>();
      this.myList.CollectionChanged += myList_CollectionChanged;
    }
    
    void myList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
            //list changed - an item was added.
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                //Do what ever you want to do when an item is added here...
                //the new items are available in e.NewItems
            }
    }
