    public string ReadValueFromSettings(string key)
    {
            _log.Info();
            string result = "ValueNotFound";
            if (_settings == null)
            {
                if(File.Exists("Settings.plist"))
                {
                    var path = NSBundle.MainBundle.PathForResource("Settings", "plist");
                    _settings = new NSDictionary(path);
                }
            }
            if(_settings != null)
            {
                var value = _settings.ValueForKey(new NSString(key));
                
                if(value != null)
                    result = value.ToString();
            }
            return result;
    }
