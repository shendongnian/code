    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    
    namespace XMLConfigurationExample
    {
        public sealed class Configuration
        {
            private readonly List<Setting> _settings = new List<Setting>();
            private readonly object _lock = new object();
            private readonly XmlSerializer _serializer;
            private const string FileName = "settings.xml";
    
            public Configuration()
            {
                _serializer = new XmlSerializer(typeof(List<Setting>));
                LoadSettings();
            }
    
            public object this[string key]
            {
                get
                {
                    Setting setting = _settings.FirstOrDefault(s => s.Key == key);
                    if (setting != null)
                    {
                        return setting.Value;
                    }
                    return null;
                }
                set
                {
                    Setting setting = _settings.FirstOrDefault(s => s.Key == key);
                    if (setting != null)
                    {
                        lock (_lock)
                        {
                            setting.Value = value;
                        }
                        SaveSettings();
                    }
                }
            }
    
            private void SaveSettings()
            {
                try
                {
                    using (FileStream fileStream = File.Open(FileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
                    {
                        _serializer.Serialize(fileStream, _settings);
                    }
                }
                catch (Exception ex)
                {
                    // here your real error handling
                    Debugger.Log(100, "Error", ex.Message);
                    throw;
                }
    
            }
    
            private void LoadSettings()
            {
                if (!File.Exists(FileName))
                {
                    return;
                }
    
                try
                {
                    using (FileStream fileStream = File.Open(FileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        ((List<Setting>)_serializer.Deserialize(fileStream)).ForEach(s => _settings.Add(s));
                    }
                }
                catch (Exception ex)
                {
                    // here your real error handling
                    Debugger.Log(100,"Error",ex.Message);
                    throw;
                }
            }
    
            public void AddSetting(string key)
            {
                if (_settings.All(s => s.Key != key))
                {
                    _settings.Add(new Setting { Key = key });
                }
            }
    
            public void RemoveSetting(string key)
            {
                Setting setting = _settings.FirstOrDefault(s => s.Key == key);
                if (setting != null)
                {
                    _settings.Remove(setting);
                }
            }
        }
    }
