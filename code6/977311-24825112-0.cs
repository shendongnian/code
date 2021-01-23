    private void RaisePropertyChanged(string propertyName)
            {
                if (Application.Current == null || Application.Current.Dispatcher.CheckAccess())
                {
                    RaisePropertyChangedUnsafe(propertyName);
                }
                else
                {
                    Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.DataBind,
                        new ThreadStart(() => RaisePropertyChangedUnsafe(propertyName)));
                }
            }
