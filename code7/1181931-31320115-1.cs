    public class DataType
    {
        public virtual void Validate()
        {
            Console.WriteLine("Performing base class validation tasks");
        }
    }
    
    class Foo : DataType
    {
        public override void Validate()
        {
            // Code to validate a foo...
            Console.WriteLine("Validating a foo");
        }
    }
    class Bar : DataType
    {
        public override void Validate()
        {
            // Code to validate a bar...
            Console.WriteLine("Validating a bar");
        }
    }
   
    
    List<DataType> datatypes = new List<DataType>();
    datatypes.Add(new Foo());
    datatypes.Add(new Barr());
     
    foreach (DataType s in datatypes)
    {
        s.Validate();
    }
