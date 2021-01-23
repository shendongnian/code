    private Database _DatabaseInfo = new Database();
    
    public MyConfiguration()
    {
      this._DatabaseInfo.PropertyChanged += new PropertyChangedEventHandler(propChanged);
    }
    
    private void propChanged(object sender, PropertyChangedEventArgs e)
    {
      // Now you can update the _DatabaseInfo.DatabaseInfo property to force the property changed event to fire.
    }
