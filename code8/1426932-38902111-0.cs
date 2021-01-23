    Style myStyle = new Style(typeof(GroupItem));    
    DataTemplate dt = new DataTemplate();
    FrameworkElementFactory spFactory = new FrameworkElementFactory(typeof(GroupItem));
    spFactory.SetValue(GroupItem.FontWeightProperty, FontWeights.Bold);
    spFactory.SetValue(GroupItem.ForegroundProperty, new SolidColorBrush(Colors.Red));
    // You missed next line
    spFactory.SetBinding(GroupItem.ContentProperty, new Binding("Name"));
    //
    dt.VisualTree = spFactory;
    GroupStyle groupStyle = new GroupStyle();
    groupStyle.HeaderTemplate = dt;
    groupStyle.ContainerStyle = myStyle;
    FCListView.GroupStyle.Add(groupStyle);
