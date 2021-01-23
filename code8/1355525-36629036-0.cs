    Application.Current.Dispatcher.BeginInvoke((System.Windows.Threading.DispatcherPriority.Normal),
                    (Action)(() =>
                    {
                        Context.Callback.Invoke();
                        IsActive = false;
                        Dispose();
                    }
                ));
