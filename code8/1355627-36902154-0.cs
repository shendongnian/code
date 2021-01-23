    public class ResourceWrapper
    {
        private ResourceManager rm;
    
        public ResourceWrapper(string name) :
            this(name, Assembly.GetCallingAssembly())
        {
        }
        public ResourceWrapper(string name, Assembly assembly)
        {
            rm = new ResourceManager(name, assembly);
        }
    
        public string myImage => rm.GetString(nameof(myImage));
    }
