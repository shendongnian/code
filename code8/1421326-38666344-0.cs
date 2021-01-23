            private static bool TransferConfig(string baseDir, ISession session)
            {
                //if (!session.LogicSettings.TransferConfigAndAuthOnUpdate)
                //    return false;
    
                var configDir = Path.Combine(baseDir, "Config");
                if (!Directory.Exists(configDir))
                    return false;
    
                var oldConf = GetJObject(Path.Combine(configDir, "config.json.old"));
                var oldAuth = GetJObject(Path.Combine(configDir, "auth.json.old"));
    
                GlobalSettings.Load("");
    
                var newConf = GetJObject(Path.Combine(configDir, "config.json"));
                var newAuth = GetJObject(Path.Combine(configDir, "auth.json"));
    
                TransferJSON(oldConf, newConf);
                TransferJSON(oldAuth, newAuth);
    
                File.WriteAllText(Path.Combine(configDir, "config.json"), newConf.ToString());
                File.WriteAllText(Path.Combine(configDir, "auth.json"), newAuth.ToString());
    
                return true;
            }
    
            private static JObject GetJObject(string filePath)
            {
                return JObject.Parse(File.ReadAllText(filePath));
            }
    
            private static bool TransferJSON(JObject oldFile, JObject newFile)
            {
                try
                {
                    foreach (var newProperty in newFile.Properties())
                        foreach (var oldProperty in oldFile.Properties())
                            if (newProperty.Name.Equals(oldProperty.Name))
                            {
                                newFile[newProperty.Name] = oldProperty.Value;
                                break;
                            }
    
                    return true;
                }
                catch
                {
                    return false;
                }
            }
