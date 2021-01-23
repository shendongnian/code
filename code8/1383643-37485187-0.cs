    public class baseclass
    {
        public void changeProperties(string propertyName, object newValue)
        {            
            var prop = GetType().GetProperty(propertyName);
            if (prop == null)
                throw new NullReferenceException("Property doesn't exist!");
            else
                prop.SetValue(this, newValue);
        }
    }
