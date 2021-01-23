    private bool _isAddedbyApp = false;
    
    private void Device_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add:
                foreach (var item in e.NewItems)
                {
					MessageBox.Show(item.
                    var entity = item as Device;
                    if (entity == null) continue;
                    if (_isAddedbyApp) continue;
    
                    _isAddedbyApp = true;
                    _context.Add(entity);
                    _isAddedbyApp = false;
                }
                break;
        }
    }
