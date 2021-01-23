     var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
     if (localSettings.Values.ContainsKey("textblockVisibility"))
     {
         var value = localSettings.Values["textblockVisibility"];
         textblock.Visibility = (bool) value ? Visibility.Visible : Visibility.Collapsed;
     }
     else
     {
          var valueToSave = textBlock.Visibility == Visibility.Visible ? true : false;
          localSettings.Values.Add("textblockVisibility", valueToSave);
     }
