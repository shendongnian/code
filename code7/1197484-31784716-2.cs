    public static class WindowClosingBehavior
    {
            public static readonly DependencyProperty ClosingProperty = DependencyProperty.RegisterAttached(
                "Closing", 
                typeof(ICommand), 
                typeof(WindowClosingBehavior),
                new UIPropertyMetadata(new PropertyChangedCallback(ClosingChanged)));
    
            private static void ClosingChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
            {
                var window = target as Window;
                if (window != null)
                {
                    if (e.NewValue != null)
                        window.Closing += Window_Closing;
                    else
                        window.Closing -= Window_Closing;
                }
            }
    
            private static void Window_Closing(object sender, CancelEventArgs e)
            {
                var window = sender as Window;
                if (window != null)
                {
                    var closing = GetClosing(window);
                    if (closing != null)
                    {
                        if (closing.CanExecute(null))
                            closing.Execute(null);
                        else
                            e.Cancel = true;
                    }
                }
            }
    }
