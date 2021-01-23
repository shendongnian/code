    private bool _isAddedbyApp = false;
    private void Device_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add:
                foreach (var item in e.NewItems)
                {
                    MessageBox.Show(item.GetType().ToString()); // if not = "Device" then tell me because there something you bind don't correct
                    var entity = item as Device;
                    if (entity != null && !_isAddedbyApp)
                    {
                        if (MessageBox.Show("Add?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            // add entity to database
                            // No need to call _devices.Add() here, you collection
                            // will auto be updated.
                        }
                        else
                        {
                            // remove this item
                            _devices.Remove(entity);
                        }
                    }
                }
                break;
        }
    }
