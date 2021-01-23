    DataTemplate dt = new DataTemplate();
    FrameworkElementFactory spFactory = new FrameworkElementFactory(typeof(TextBlock));
    spFactory.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);
    spFactory.SetValue(TextBlock.ForegroundProperty, new SolidColorBrush(Colors.Red));
    spFactory.SetBinding(TextBlock.TextProperty, new Binding("Name"));
    dt.VisualTree = spFactory;
    GroupStyle groupStyle = new GroupStyle();
    groupStyle.HeaderTemplate = dt;
    
    FCListView.GroupStyle.Add(groupStyle);
