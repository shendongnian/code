     foreach (KeyValuePair<string, MyObjects> entry in MyDictionary)
        {
            MyTextblock = new TextBlock();
            MyTextblock.Margin = new Thickness(0, 5, 0, 0);
            MyStackPanel.Children.Add(MyTextblock);
            MyTextblock.Text = entry.Value.name;
        }
