      SortDescriptionCollection my = new SortDescriptionCollection();
    
      // you can't do this (it should not compile)
      // since "CollectionChanged" is protected
      my.CollectionChanged += (sender, e) => Console.Write("hello from event!");
    
      // however, since SortDescriptionCollection implements SortDescriptionCollection
      // you can cast to the interface
      INotifyCollectionChanged hack = my as SortDescriptionCollection;
    
      // wow! you can access "protected" event as if it's public one! 
      // So isolation is violated
      hack.CollectionChanged += (sender, e) => Console.Write("hello from hacked event!");
