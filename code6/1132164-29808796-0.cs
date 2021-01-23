    public class Property
    {
        public string alias { get; set; }
        public string value { get; set; }
    }
    
    public class Fieldset
    {
        public List<Property> properties { get; set; }
        public string alias { get; set; }
        public bool disabled { get; set; }
    }
    
    public class RootObject
    {
        public List<Fieldset> fieldsets { get; set; }
    }
