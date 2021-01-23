    public abstract class BaseClass<TExists> where TExists : BaseExists
    {
        // needs to be overridden by child
        protected abstract bool InternalExistsCheck<T>(TExists existsData, out T existingElement) where T : BaseClass<TExists>, new();
        // static method to be invoked without any need of an instance
        public static bool Exists<T>(TExists existsData, out T existingElement) where T : BaseClass<TExists>, new()
        {
            T temp; // <-- how to set the type here?
            existingElement = null;
            // create a concrete instance
            var instance = new T();
            // call the concrete implementation
            if (instance.InternalExistsCheck(existsData, out temp))
            {
                existingElement = temp;
                return true;
            }
            return false;
        }
    }
