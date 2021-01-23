    public void TestMethod()
    {
        DataTemplate dt = FlipView5Horizontal.ItemTemplate;
        DependencyObject dio = dt.LoadContent();
        foreach (var timeLine in FindVisualChildren<TextBlock>(dio)) //FindVisualTree is defined in the question :)
        {
            if (timeLine.Name == "xxxTB")
            { }
        }
    }
