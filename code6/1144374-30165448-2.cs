    foreach (MyObjects Value in MyDictionary.Values)
    {
        MyTextblock = new TextBlock();
        MyTextblock.Margin = new Thickness(0, 5, 0, 0);
        MyStackPanel.Children.Add(MyTextblock);
        MyTextblock.Text = Value.name;
    }
