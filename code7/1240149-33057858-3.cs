    public class Person
    {
        public virtual string Name { get; set; }
    }
    public class Spy : Person
    {
        public override string Name
        {
            get
            {
                throw new Exception("You never ask for a spy's name!");
            }
            set
            {
                base.Name = value;
            }
        }
    }
