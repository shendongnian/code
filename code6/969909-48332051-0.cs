    public class ConfigurationElementCollectionExtension : ConfigurationElementCollection, IConfigurationElementCollectionExtension
        {
            protected override ConfigurationElement CreateNewElement()
            {
                throw new NotImplementedException();
            }
    
            protected override object GetElementKey(ConfigurationElement element)
            {
                throw new NotImplementedException();
            }
    
            bool IConfigurationElementCollectionExtension.ContainsKey<T>(T key)
            {
                bool returnValue = false;
    
                object[] keys = base.BaseGetAllKeys();
    
                string keyValue = key.ToString();
                int upperBound = keys.Length;
                List<string> items = new List<string>();
    
                for (int i = 0; i < upperBound; i++)
                {
                    items.Add(keys[i].ToString());
                }
    
                int index = items.IndexOf(keyValue);
                if (index >= 0)
                {
                    returnValue = true;
                }
    
                
                return returnValue;
            }
        }
