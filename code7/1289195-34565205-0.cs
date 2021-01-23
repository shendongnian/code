    ObservableCollection<TheClass> ob1 = new ObservableCollection<TheClass>();
    ob1.Add(...);
    ob1.Add(...); 
    ob1.Add(...);
    ob1.Add(...); 
    ObservableCollection<TheClass> ob2;
    // ob2 = ob1.Range(0, 2);
    ob2 = new ObservableCollection(ob1.Skip(0).Take(2));
