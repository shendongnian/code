    public class Root
    {
        public SpecialProperty Name { get; set; }
        public SpecialProperty Surname { get; set; }
        public Root()
        {
            this.Name = SpecialProperty.GetEmptyInstance();
            this.Surname = SpecialProperty.GetEmptyInstance();
        }
    }
    
    public class SpecialProperty
    {
        public string Name { get; set; }
        public string Type { get; set; }
    
        public static SpecialProperty GetEmptyInstance()
        {
             return new SpecialProperty
             {
                  Name = string.Empty,
                  Type = string.Empty
             };
        }
    }
