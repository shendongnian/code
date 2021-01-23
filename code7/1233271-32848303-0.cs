    public enum PersonType
    {
      [PersonClass(typeof(Customer)]
      Customer,
      [PersonClass(typeof(EndUser)]
      EndUser,
      [PersonClass(typeof(Supplier)]
      Supplier,
    }
    public class PersonClassAttribute : System.Attribute 
    {
        public Type Type { get; }
        public PersonClassAttribute(Type type)
        {
            Type = type;
        }
    }
