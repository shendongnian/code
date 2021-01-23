    public class ObjectB : ObjectA
    {
        public int propertyB1 { get; set; }
        public int propertyB2 { get; set; }
        // ...
        public ObjectA CreateA()
        {
            Type type = typeof(ObjectA);
            ObjectA result = new ObjectA();
            
            foreach (PropertyInfo propertyInfo in type.GetProperties())
            {
                if (propertyInfo.CanRead)
                {
                    object value = propertyInfo.GetValue(this, null);
                    propertyInfo.SetValue(result, value);
                }
            }
            return result;
        }
    }
