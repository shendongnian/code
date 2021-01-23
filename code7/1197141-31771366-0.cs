    private async void LoginBtn_Click(object sender, RoutedEventArgs e) 
     {
       Loading.Visibility = Visibility.Visible; //The loading animation
    
       Loading.Visibility = Visibility.Visible;
       Cursor = Cursors.Wait;      
    
       LoginVerification loginInfoVerification = null;
    
       await Task.Run(() =>
                     {
                         loginInfoVerification = config.ServerConnection(loginInfo.userName, 
                                                                         loginInfo.galPassword, 
                                                                         loginInfo.place, 
                                                                         loginInfo.host, 
                                                                         loginInfo.port, 
                                                                         loginInfo.application);
                     });   
          
          .. rest of code, check login success, show message box..
     }
