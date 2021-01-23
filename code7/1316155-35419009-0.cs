    StackLayout objStackLayout = new StackLayout()
    {
        Orientation = StackOrientation.Vertical,
    };
    ListView objListView = new ListView();
    objStackLayout.Children.Add(objListView);
    objListView.ItemTemplate = new DataTemplate(typeof(MyViewCell));
    ObservableCollection<MyPubClass> objItems = new ObservableCollection<MyPubClass>();
    objListView.ItemsSource = objItems;
    objItems.Add(new MyPubClass(Color.Red));
    objItems.Add(new MyPubClass(Color.Green));
    objItems.Add(new MyPubClass(Color.Blue));
    Button objButton1 = new Button()
    {
        Text = "Change Colors"
    };
    objButton1.Clicked+=((o2,e2)=>
    {
        foreach (MyPubClass objItem in objItems)
        {
            if (objItem.TheBackgroundColor == Color.Red)
            {
                objItem.TheBackgroundColor = Color.Green;
            }
            else if (objItem.TheBackgroundColor == Color.Green)
            {
                objItem.TheBackgroundColor = Color.Blue;
            }
            else if (objItem.TheBackgroundColor == Color.Blue)
            {
                objItem.TheBackgroundColor = Color.Red;
            }
        }
    });
    objStackLayout.Children.Add(objButton1);
