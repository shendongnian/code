    public class Derived : Base
    {
        public Derived(Base b)  
        {
            SetInheritedProperties(b);
        }
    
        private void SetInheritedProperties (object baseClassInstance)
        {
            foreach (PropertyInfo propertyInfo in baseClassInstance.GetType().GetProperties())
            {
                object value = propertyInfo.GetValue(baseClassInstance, null);
                if (null != value) propertyInfo.SetValue(this, value, null);
            }
        }
    }
