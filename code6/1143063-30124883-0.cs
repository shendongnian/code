                ExecutedRoutedEventArgs args = new ExecutedRoutedEventArgs(this, parameter);
                args.RoutedEvent = CommandManager.PreviewExecutedEvent;
                
                if (targetUIElement != null)
                {
                    targetUIElement.RaiseEvent(args, userInitiated);
                }
                else
                {
                    ...
                }
                if (!args.Handled)
                {
                    args.RoutedEvent = CommandManager.ExecutedEvent;
                    if (targetUIElement != null)
                    {
                        targetUIElement.RaiseEvent(args, userInitiated);
                    }
                    ...
                }
