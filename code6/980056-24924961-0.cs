     protected override void OnBackKeyPress(CancelEventArgs e)
            {
        
        
                base.OnBackKeyPress(e);
                e.Cancel = true;
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                               {
                                   MessageBoxResult result = MessageBox.Show("Hello", "Msg Box", MessageBoxButton.OKCancel);
                                   if (result == MessageBoxResult.OK)
                                   {
                                       //Do something
                                   }
                                   else
                                   {
                                       //Do something
                                   }
                               });
        
        
        
            }
