    public class Entry
    {
       public string Directory { get; set; }
       public string SettingName {get; set;}
       public bool Exists {get; private set;}
       
       public bool CheckDirectory(Configuration config){
            if (Directory.Exists(Directory ) ){
              config.AppSettings.Settings[directorySettings].Value = Directory;
              Exists = true;
              return true;
            }
            else{
              Exists = false;
              return false;
            }
       }
    }
