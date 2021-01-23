    public class AppSettingWrapperAttribute : DictionaryBehaviorAttribute, IDictionaryKeyBuilder, IPropertyDescriptorInitializer, IDictionaryPropertyGetter
    {
        public string GetKey(IDictionaryAdapter dictionaryAdapter, string key, PropertyDescriptor property)
        {
            return key;
        }
        
        public object GetPropertyValue(IDictionaryAdapter dictionaryAdapter, string key, object storedValue, PropertyDescriptor property, bool ifExists)
        {
            return storedValue;
        }
        
        public void Initialize(PropertyDescriptor propertyDescriptor, object[] behaviors)
        {
            propertyDescriptor.Fetch = true;
        }
