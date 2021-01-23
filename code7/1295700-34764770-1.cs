    public void Remove(Data d)
    {
        ((ObservableCollection<Data>) ListView.ItemsSource).Remove(d);
    }
...
    ListView.ItemsSource = new ObservableCollection<Data>()
    {
        new Data() {Id = 1, Text = "1", OnRemoveCallback = Remove},
        new Data() {Id = 2, Text = "2", OnRemoveCallback = Remove}
    };
