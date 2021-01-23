    internal class WindowExtensions
    {
    	public static readonly DependencyProperty WindowClosingCommandProperty = DependencyProperty.RegisterAttached(
    		"WindowClosingCommand", typeof (ICommand), typeof (WindowExtensions), new PropertyMetadata(null, OnWindowClosingCommandChanged));
    
    	private static void OnWindowClosingCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    	{
    		Window window = d as Window;
    		if (window == null)
    			return;
    
    		if (e.NewValue != null)
    		{
    			window.Closing += WindowOnClosing;
    		}
    	}
    
    	private static void WindowOnClosing(object sender, CancelEventArgs e)
    	{
    		Window window = sender as Window;
    		if (window == null)
    			return;
    
    		ICommand windowClosingCommand = GetWindowClosingCommand(window);
    		windowClosingCommand.Execute(e);
    	}
    
    	public static void SetWindowClosingCommand(DependencyObject element, ICommand value)
    	{
    		element.SetValue(WindowClosingCommandProperty, value);
    	}
    
    	public static ICommand GetWindowClosingCommand(DependencyObject element)
    	{
    		return (ICommand) element.GetValue(WindowClosingCommandProperty);
    	}
    }
