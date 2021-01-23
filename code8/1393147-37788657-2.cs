    void Main()
    {
    	StackPanel sp = new StackPanel();
    	for (int i = 0; i < 10; i++)
    	{
    		Border b = new Border()
    		{
    			BorderBrush = new SolidColorBrush(
    			i % 2 == 0
    			? Color.FromArgb(0xFF, 0x80, 0x80, 0x80)
    			: Color.FromArgb(0xFF, 0xFF, 0x0, 0x0)
    			),
    			BorderThickness = new Thickness(1, 0, 1, 2),
    			CornerRadius = new CornerRadius(1, 1, 1, 5),
    			Child = new RichTextBox()
    		};
    		sp.Children.Add(b);
    	}
    
    	new Window { Content = sp }.ShowDialog();
    	Dispatcher.CurrentDispatcher.InvokeShutdown();
    }
