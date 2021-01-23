    ObservableCollection<string> list;
    private void Form1_Load(object sender, EventArgs e)
    {
        list = new ObservableCollection<string>();
        list.CollectionChanged += list_CollectionChanged;
        list.Add("Item 1");
        list.Add("Item 2");
        list.RemoveAt(0);
        list[0] = "New Item";
    }
    void list_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.Action == NotifyCollectionChangedAction.Add)
        {
            var items = string.Join(",", e.NewItems.Cast<String>());
            MessageBox.Show(string.Format("'{0}' Added", items));
        }
        else if (e.Action == NotifyCollectionChangedAction.Remove)
        {
            var items = string.Join(",", e.OldItems.Cast<String>());
            MessageBox.Show(string.Format("'{0}' Removed", items));
        }
        else if (e.Action == NotifyCollectionChangedAction.Replace)
        {
            var oldItems = string.Join(",", e.OldItems.Cast<String>());
            var newItems = string.Join(",", e.NewItems.Cast<String>());
            MessageBox.Show(string.Format("'{0}' replaced by '{1}'", oldItems, newItems));
        }
        else
        {
            MessageBox.Show("Reset or Move");
        }
    }
