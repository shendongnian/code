    public static void UIThread(Action action)
        {
            if (_d == null)
            {
                if (Application.Current != null)
                {
                    _d = Application.Current.Dispatcher;
                }
                else
                {
                    _d = Dispatcher.CurrentDispatcher;
                }
            }
            _d.Invoke(action);
        }  
