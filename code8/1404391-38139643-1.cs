    public class Derived : Base
    {
        public string Description
        {
            get;
            set;
        }
        public override string ToString()
        {
            return base.ToString() + " - " + Description;
        }
    }
