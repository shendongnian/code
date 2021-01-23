    public void OnChange()
    {
        Data = new ObservableCollection<DataList>();//Note the use of Data property not field
        Data.Add(new DataList() { Text = "Changed 1" });
        Data.Add(new DataList() { Text = "Changed 2" });
    }
