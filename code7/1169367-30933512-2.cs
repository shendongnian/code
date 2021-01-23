    Task.Factory.StartNew(() =>
    {
           Dispatcher.Invoke(() => 
           {
              FillTreeView(); // this will fill some items in treeview so Dispatcher must be used
           }
    });
          
