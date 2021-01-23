        private void SomeWork()
                {
                    try
                    {
                        // Do Work
                        // ...
                
                        // Return when done.
                       App.Current.Dispatcher.Invoke((Action)delegate
                        {
    
                        _regionManager.RequestNavigate("MyTarget", nameof(SomePage));
    
                        });
                    }
                    catch
                    {
                      App.Current.Dispatcher.Invoke((Action)delegate
                        {
    
                        _regionManager.RequestNavigate("MyTarget", nameof(SomeErrorPage));
                        });
                    }        
            }
