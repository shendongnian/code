    public class Settings
    {
            static FileIniDataParser _parser = new FileIniDataParser();
            IniData _data;
            public Settings()
            {
                if (!File.Exists("Config.ini"))
                {
                  // create the config file 
                }
    
                _data = _parser.ReadFile("Config.ini");
            }
    
            public int GetInt(string section, string key)
            {
                string keyValue = _data[section][key];
                int setting = int.Parse(keyValue);
                return setting;
            }
    }
