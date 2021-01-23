     private void ExecuteCommand(object obj)
     {
          LabelVisibility = Visibility.Visible;
          Application.Current.Dispatcher.Invoke((Action)(() => { }), DispatcherPriority.Render);
          //// Do your code here
        
          LabelVisibility = Visibility.Collapsed;
     }
