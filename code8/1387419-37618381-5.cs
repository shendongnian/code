    public class Address 
    {
        public virtual string Street {get; set;}
        public virtual string Number {get; set;}
        public virtual string City {get; set;}
        ...
    
        public string ToJSON()
        { 
            // Encode the object as as JSON string
            ...
            return strJSON;
        }
    
        public Address(string json)
        {
            // Decode JSON string and set object properties
            ...
        }
    }
