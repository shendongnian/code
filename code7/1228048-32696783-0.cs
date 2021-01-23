    public class Settings
        {
            private readonly IniData _data;
           
            private Settings(IniData data){
                _data = data;
            }
    
            public static Settings InitFrom(string fname){
               static FileIniDataParser _parser = new FileIniDataParser();
               IniData data = _parser.ReadFile("Config.ini");
               return new Settings(data);
            }
       
            public int GetInt(string section, string key)
            {
                string keyValue = _data[section][key];
                int setting = int.Parse(keyValue);
                return setting;
            }
    }
