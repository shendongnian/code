    Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, new DispatchedHandler(() =>
                {
                    Frame thisFrame = Window.Current.Content as Frame;
                    Window.Current.Activate();
                    thisFrame.Navigate(typeof(Target));
                }));
