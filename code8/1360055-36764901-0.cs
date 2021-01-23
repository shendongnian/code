    public void BeginUpdate() {
        _disableNotifications = true;
    }
    
    public void EndUpdate() {
        _disableNotifications = false;
        
        if (_changed) {
            OnCollectionChanged(
                new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
    
            _changed = false;
        }
    }
    
    protected override OnCollectionChanged(NotifyCollectionChangedEventArgs e) {
        if (_disableNotifications)
            _changed = true;
        else
            base.OnCollectionChanged(e);
    }
