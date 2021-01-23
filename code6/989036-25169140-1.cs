    var original = new ObservableCollection<string> { "1", "2", "3", "4", "5, "6", "7", "8", "9" };
    
    original.CollectionChanged += (s, e) => {
      if(e.Action == NotifyCollectionChangedAction.Add) {
        //Store or do something with added items in e.NewItems.
      } 
      else if (e.Action == NotifyCollectionChangedAction.Remove {
        //store or do something with removed items in e.OldItems
      }
    };
    
    original.Add("15");
    original.RemoveAt(3);
