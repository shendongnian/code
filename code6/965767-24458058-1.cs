    abstract class Base
    {
        public bool TryGetValue(string key, out object value)
        {
            try
            {
                value = GetValue(key);
                return true;
            }
            catch (Exception e)
            {
                value = null;
                return false;
            }
        }
    
        public abstract object GetValue(string key);
    }
    
    class Derived : Base
    {
        public override object GetValue(string key)
        {
            throw new Exception();
        }
    }
