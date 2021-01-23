    abstract class Base
    {
        // A "safe" version of the GetValue method.
        // It will never throw an exception, because of the try-catch.
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
    
        // A potentially "unsafe" method that gets a value by key.
        // Derived classes can implement it such that it throws an
        // exception if the given key has no associated value.
        public abstract object GetValue(string key);
    }
    
    class Derived : Base
    {
        // The derived class could do something more interesting then this,
        // but the point here is that it might throw an exception for a given
        // key. In this case, we'll just always throw an exception.
        public override object GetValue(string key)
        {
            throw new Exception();
        }
    }
