     // lock PI over process , reflectin data is collected once over all threads for performance reasons.
     private static Object _pilock = new Object();   
     private static Dictionary<string, PropertyInfo> _propInfoDictionary;
    public PropertyInfo GetProperty(string logicalKey) {
            // try from dict first
            PropertyInfo pi;
            // lock access to static for thread safety
            lock (_pilock) {
                if (_propInfoDictionary.TryGetValue(logicalKey, out pi)){
                    return pi;
                }    
            
            
            pi = new PropertyInfo;
            // set pi ...... do whatever it takes to prepare the object before saving in dictionary
                _propertyInfoDictionary.Add(logicalKey, pi);    
            } // end of lock period
            
            return pi;
        }
