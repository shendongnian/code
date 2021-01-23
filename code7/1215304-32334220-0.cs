    public class ModelBase
    {
        public bool IsDirty { get; set; }
    }
    
    public class EmpModel : ModelBase
    {        
        public int ID { get; set; }
    
        public string Name {get; set;}
    
        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                // Only if change comes from the user...
                IsDirty = true;
            }
        }
        private int _age;
    }
