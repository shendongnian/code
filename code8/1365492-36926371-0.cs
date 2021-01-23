    public class MyMutableSettings : ISettings
    {
        public ISettings Settings {get;set;}
    
        //Implement the ISettings interface by delegating to Settings, e.g.:
        public int GetNumberOfCats()
        {
            return Settings.GetNumberOfCats();
        }
    }
