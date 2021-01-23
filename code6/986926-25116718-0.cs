    // in your controller, when you assign the source
    this.TableView.Source = new MyTableViewSource(this);
    
    // in your source, keep a class level ref to the parent
    MyTableViewController _parent;
    
    // your Source's constructor
    public MyTableViewSource(MyTableViewController parent) {
      _parent = parent;
    }
    
    // finally, in your RowSelected use the _parent reference to access the Nav controller
    var detailController = new DetailViewController ();
    _parent.NavigationController.PushViewController(detailController, true);
