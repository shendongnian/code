    public static class WindowEventHelpers
        {
            #region Static Fields
    
            /// <summary>
            /// Attached property to define the command to run when the windows is closing
            /// </summary>
            public static readonly DependencyProperty WindowClosingCommandProperty = DependencyProperty.RegisterAttached(
                "WindowClosingCommand",
                typeof(ICommand),
                typeof(WindowEventHelpers),
                new PropertyMetadata(null, OnWindowClosingCommandChanged));
    
    
            #endregion
    
            #region Public Methods and Operators
    
            /// <summary>
            /// Returns the WindowClosingCommand dependency property value.
            /// </summary>
            /// <param name="target">
            /// The <see cref="DependencyProperty"/> identifier.
            /// </param>
            /// <returns>
            /// The WindowClosingCommand dependency property value.
            /// </returns>
            public static ICommand GetWindowClosingCommand(DependencyObject target)
            {
                return (ICommand)target.GetValue(WindowClosingCommandProperty);
            }
    
            /// <summary>
            /// Set the WindowClosingCommand dependency property value
            /// </summary>
            /// <param name="target">
            /// The <see cref="DependencyProperty"/> identifier.
            /// </param>
            /// <param name="value">
            /// The dependency property value.
            /// </param>
            public static void SetWindowClosingCommand(DependencyObject target, ICommand value)
            {
                target.SetValue(WindowClosingCommandProperty, value);
            }
    
            /// <summary>
            /// Returns the WindowClosingCommand dependency property value.
            /// </summary>
            /// <param name="target">
            /// The <see cref="DependencyProperty"/> identifier.
            /// </param>
            /// <returns>
            /// The WindowClosingCommand dependency property value.
            /// </returns>
            public static ICommand GetWindowContentRenderedCommand(DependencyObject target)
            {
                return (ICommand)target.GetValue(WindowContentRenderedCommandProperty);
            }
    
            #endregion
    
            #region Methods
    
            private static void ClosingEventHandler(object sender, CancelEventArgs e)
            {
                var control = (Window)sender;
                var command = (ICommand)control.GetValue(WindowClosingCommandProperty);
                command.Execute(e);
            }
    
    
            private static void OnWindowClosingCommandChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
            {
                var command = (ICommand)e.NewValue;
    
                if (target is Window)
                {
                    // var fe = (FrameworkElement)target;
                    var control = (Window)target;
    
                    //check if we need to add the event handler or we need to remove it
                    if ((command != null) && (e.OldValue == null))
                    {
                        control.Closing += ClosingEventHandler;
                    }
                    else if ((command == null) && (e.OldValue != null))
                    {
                        control.Closing += ClosingEventHandler;
                    }
                }
            }
    
    
            #endregion
        }
