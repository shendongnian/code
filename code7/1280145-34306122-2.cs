    List<SomeClass> list = new List<SomeClass>();
    Random rnd = new Random();
    for (int i = 0; i < 10; i++)
    {              
       list.Add(new SomeClass() { DaysOld = DateTime.Now.Add(new TimeSpan(0, rnd.Next(25), 0))});
    }
    ICollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(list);
    PropertyGroupDescription groupDescription = new PropertyGroupDescription("daysOld");
    view.GroupDescriptions.Add(groupDescription);
    view.SortDescriptions.Add(new SortDescription("DaysOld",   ListSortDirection.Descending));
    listBox.ItemsSource = view;
    listBox.DisplayMemberPath = "DaysOld";
