    using System.Collections.Specialized;
    bool isAddedbyApp = false;
    void o_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.Action == NotifyCollectionChangedAction.Add) // User add new item
        {
            foreach(var item in e.NewItems)
            {
                if (!isAddedbyApp)
                {
                    var entity = item as Device; // or your Model
                    // Do some thing here: ask user, ..., validate value
                    // If you don't want this item, you call call remove function to remove it
                }
            }
        }
    }
