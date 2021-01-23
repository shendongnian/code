    ListView lv = new ListView();
    lv.HorizontalOptions = LayoutOptions.FillAndExpand;
    lv.VerticalOptions = LayoutOptions.FillAndExpand;
    lv.SetBinding(ListView.ItemsSourceProperty, new Binding("A"));
    lv.ItemSelected += (sender, args) =>
    {
        onclick(sender, args);
    }; //Remember to remove this event handler on dispoing of the page;
    DataTemplate dt = new DataTemplate(typeof(TextCell));
    dt.SetBinding(TextCell.TextProperty, new Binding("b"));
    dt.SetBinding(TextCell.DetailProperty, new Binding("c"));
    lv.ItemTemplate = dt;
