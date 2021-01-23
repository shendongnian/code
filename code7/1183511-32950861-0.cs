         public class LocalSetting
    {
       
       public LocalSetting()
       {
       }
       public void Write(string key,string value)
       {
           try
           {
               var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
               localSettings.Values[key] = value;
           }
           catch(Exception)
           {
               MessageDialog msgbox = new MessageDialog("Erreur d'ecriture");
               msgbox.ShowAsync();
               return;
           }
       }
       public String Read(string key)
       {
           try
           {
           var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
           if(localSettings.Values.Keys.Contains(key))
          return localSettings.Values[key].ToString();
           else 
          return "";
             }
           catch(Exception)
           {
               MessageDialog msgbox = new MessageDialog("Erreur de lecture");
               msgbox.ShowAsync();
               return "";
           }
       }
    }
