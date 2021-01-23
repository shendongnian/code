    public class Generic<T>
    {
        public System.Reflection.PropertyInfo[] GetAllProperties()
        {
            return typeof(T).GetProperties();
        }
    }
