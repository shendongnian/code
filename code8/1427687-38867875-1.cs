    private async void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
         var newText = e.NewTextValue;
         //once 3 keystroke is visible by 3
         if (newText.Length % 3 == 0)
         {
              //Call the web services
              var result = await getModelStringForVIN(newText);
              if (string.IsNullOrEmpty(result) == false)
              {
                   ModelVIN.Text = result;
              }    
         }
    } 
    private async Task<string> getModelStringForVIN(string vinText)
    {
          var deviceId = CrossDeviceInfo.Current.Model;
          deviceId = deviceId.Replace(" ", string.Empty);
          var requestMgr = new RequestManager(deviceId);
    
          var VinData = await requestMgr.getModelForVIN(vinText);
    
          return VinData?.Model;
     }
