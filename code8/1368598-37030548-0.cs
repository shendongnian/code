    var query1 = MyCollection.Where(w => w.ItemA == "LOVEU");
    var query2 = MyCollection.Where(w => w.ItemA != "LOVEU");
    MyCollection = new ObservableCollection<MyModel>(query2);
    foreach (var item in query1)
    {
        MyCollection.Insert(0,item);
    }
