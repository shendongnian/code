    public class MyObject()
    {
        public string Name { get; set; }
        public override bool Equals(object obj) 
        { 
            if (obj == null) 
                return false; 
            if (obj is string)
                return (string)obj == this.Name;
            if (obj is MyClass)
                return ((MyClass)obj).Name == this.Name); 
            return false;
        }
    }
