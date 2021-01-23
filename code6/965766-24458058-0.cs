    abstract class Base
    {
        public bool TryGetValue(out object value)
        {
            try
            {
                value = G();
                return true;
            }
            catch (Exception e)
            {
                value = null;
                return false;
            }
        }
    
        public abstract object GetValue();
    }
    
    class Derived : Base
    {
        public override object GetValue()
        {
            throw new Exception();
        }
    }
