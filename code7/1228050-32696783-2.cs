    public class Settings
        {
            private readonly IniData _data;
           
            private Settings(IniData data){
                _data = data;
            }
    
            public static Settings InitFrom(string fname){
               var _parser = new FileIniDataParser();
               var data = _parser.ReadFile(fname);
               return new Settings(data);
            }
       
            public int GetInt(string section, string key)
            {
                string keyValue = _data[section][key];
                int setting = int.Parse(keyValue);
                return setting;
            }
    }
