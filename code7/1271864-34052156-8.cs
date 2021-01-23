   
    var items = new ObservableCollection<MyDataObject>();
    items.Add(new MyDataObject() { Caption = "A" });
    items.Add(new MyDataObject() { Caption = "B" });
    items.Add(new MyDataObject() { Caption = "C" });
    items.Add(new MyDataObject() { Caption = "D" });
    items.Add(new MyDataObject() { Caption = "E" });
    myItemsControl.ItemsSource = items;
