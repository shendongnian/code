    public interface IModule
    {
        Person GetPerson();
        void Print();
    
        void SaveState(string file);
        void LoadState(string file);
    }
    
    public class ModuleLoader : MarshalByRefObject
    {
        public IModule Module { get; set; }
    
        public void Initialize(string path)
        {
            // Load the module
            // Setup file watcher
        }
    
        public void SaveState(string file)
        {
            this.Module.SaveState(file);
        }
            
        public void LoadState(string file)
        {
            this.Module.LoadState(file);
        }
    }
