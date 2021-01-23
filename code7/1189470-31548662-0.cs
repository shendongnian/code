    public class PropertyClass<TMyProperty>
    {
        public List<TMyProperty> Settings { get; set; }
    
        public PropertyClass()
        {                                   
            Settings = new List<TMyProperty>();
        }
        ..
     }
