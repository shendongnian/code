    public class Person
    {
        public int ID { get; set; }
      
        public override bool Equals(object o)
        {
            return ID == (o as Person)?.ID;
        }
        public override int GetHashCode()
        {
            return ID;
        }
    }
