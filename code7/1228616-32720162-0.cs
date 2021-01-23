    public class Factory {
    
        //store how different objects are created
        private IDictionary<string, Func<IImportService>> mappings = new Dictionary<string, Func<IImportService>>()
        public void Register(string key, Func<IImportService> expression) 
        {
             mappings[key] = expression;
        }
        public IImportService GetService(string key)
        {
             return mappings[key]();
        }
    }
