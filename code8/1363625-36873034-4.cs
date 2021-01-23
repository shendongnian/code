    public abstract class BaseClass
    {
        protected BaseClass(int value)
        {
            _value = value;
        }
        private int _value;
        public virtual int Value { get { return _value; } set { _value = value; } }
    }
    public class SubClass : BaseClass
    {
        public SubClass(int value) : base(value)
        {
        
        }
        public new int Value { get; set; } // hides base class member
    }
