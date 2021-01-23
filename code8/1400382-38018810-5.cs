    public class Employee : ICloneable
    {
        public string ID {get;set;}
        public string Name {get;set;}
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
