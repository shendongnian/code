    public class AnotherThing : Thing 
    {
        AnotherThing (Thing value)
        {
            this.Property = value.Property;
        }
        public string AnotherProperty {get;set;}
    }
