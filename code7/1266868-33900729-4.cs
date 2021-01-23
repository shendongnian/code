    vm.List.CollectionChanged += List_CollectionChanged;
    void List_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
            {
                MessageBox.Show(e.Action.ToString());
            }
