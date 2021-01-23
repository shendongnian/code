    public class Base
    {
        public virtual void Validate()
        {
            Console.WriteLine("Validation for base");
        }
    }
    public class Derived : Base
    {
        public override void Validate()
        {
            base.Validate();  // optional
            Console.WriteLine("Validation for Derived");
        }
    }
