        var tabItem = new TabItem();
        var stack = new StackPanel();
        var t = new TextBlock();
        t.Text = "My Tab Header";
        var i = new Image();
        //i.Source = ...
        stack.Children.Add(t);
        stack.Children.Add(i);
        tabItem.Header = stack;
        tabItem.Content = new StackPanel();
        tab.Items.Add(tabItem);
