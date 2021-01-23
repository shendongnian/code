    public ObservableCollection<ConnSet> Items { get; set; }
    private void ConSel_Click(object sender, RoutedEventArgs e)
    {
        if (ListB.SelectedItem != null)
        {
            string name = ((ListBoxItem)ListB.SelectedItem).Name;                
            ConnSet CSobj = new ConnSet();
            Items.Add(CSobj); // with the correct bindings, this will push to the UI for you
        }                        
    }
