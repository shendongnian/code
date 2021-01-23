    public static class SomeUtilityClass {        
        public static IApplicationSettings Application {get;set;}
    
        public static void UpdateApplicationVariable(string keyToUpdate, object toSave)
        {
            Application[keyToUpdate] = toSave;
        }
        
        public static object GetApplicationVariable(string keyToReturn)
        {
            return Application[keyToReturn];
        }    
    }
