    [ImplementPropertyChanged]
    public class person
    {
        public string name { get; set; }
    
        public override string ToString()
        {
            return this.name;
        }
    }
