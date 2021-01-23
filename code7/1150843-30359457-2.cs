    while (!_cancelTasks)
    {
       //BlockingCollections with Paralell ForEach
       var bc = _concurrentCollection;
       var q = new ConcurrentBag<ScannedPage>();
       Parallel.ForEach(bc.GetConsumingEnumerable(), item =>
       {
          ScannedPage currentPage = item;
          q.Add(item);
          // process a batch of images from the bc and check if an image has a valid barcode. T
       });
     //Here should go the code that takes the results from each tasks, process them in the same FIFO order in which they entered the BC and save each image to a file, all of this in this same thread.
                  
      //process items in your queue here
      var items = q.OrderBy( o=> o.SeqNbr).ToList();
      foreach( var item in items){
         ...
      }
    }
