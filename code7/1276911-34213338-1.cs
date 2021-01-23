    public class DerivedClass : BaseClass<DerivedClass>
    {
        public int B {get ; set; }
        public DerivedClass SetPropertyB(int value)
        {
            this.B=value;
            return this;
        }
    }
