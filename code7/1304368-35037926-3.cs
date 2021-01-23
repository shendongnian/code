    public class Derived : Base
    {
        public Derived(Base b)  
        {
            SetInheritedProperties(b);
        }
    
       private void SetInheritedProperties(object mainClassInstance)
        {
            var properties = mainClassInstance.GetType()
               .GetProperties();
            foreach (var propertyInfo in properties)
            {
                object value = propertyInfo.GetValue(mainClassInstance, null);
                if (null != value)
                    propertyInfo.SetValue(this, value, null);
            }
        }
    }
