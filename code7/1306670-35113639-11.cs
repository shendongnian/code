    public void Evaluate(int SpreadMax)
    {
        SpreadMax = 1;
        UIElementOut.SliceCount = 1;
        for (var i = 0; i < SpreadMax; i++)
        {
            if (UIElementOut == null || !(UIElementOut[i] is TabControl))
                UIElementOut[i] = new TabControl();
                var uiElement = (TabControl)UIElementOut[i];
                uiElement.Height = 200;
                uiElement.Width = 500;
        }
        Grid grid = new Grid();
		var listOfElements = new List<UIElements>
		{
                new Button {Background = Brushes.Tomato, Content = "Click Me"},
                new Button {Background = Brushes.Yellow, Content = "Click Me"},
                new Button {Background = Brushes.Green, Content = "Click Me"},
                new Button {Background = Brushes.Blue, Content = "Click Me"}
        };
		listOfElements.ForEach(button => grid.Children.Add(button));
		((TabControl)UIElementOut[0]).Items.Add(new TabItem { Header = "Objects", Content = grid });
    }
