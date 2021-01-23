    public class ExpandedObjectFromApi : DynamicObject
    {
        private Dictionary<string, object> _customProperties = new Dictionary<string, object>();
        private object _currentObject;
        public ExpandedObjectFromApi(dynamic sealedObject)
        {
          _currentObject = sealedObject;
        }
        private PropertyInfo GetPropertyInfo(string propertyName) 
        { 
           return _currentObject.GetType().GetProperties().FirstOrDefault
          	(propertyInfo => propertyInfo.Name == propertyName); 
        } 
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
          var prop = GetPropertyInfo(binder.Name);
          if(prop != null)
          {
             result = prop.GetValue(_currentObject);
             return true;
          }
          result = _customProperties[binder.Name];
          return true;          
        }      
        public override bool TrySetMember(GetMemberBinder binder, object value)
        {
          var prop = GetPropertyInfo(binder.Name);
          if(prop != null)
          {
             prop.SetValue(_currentObject, value);
             return true;
          }
          if(_customProperties.ContainsKey(binder.Name))
            _customProperties[binder.Name] = value;
          else
            _customProperties.Add(binder.Name, value);
          return true;          
        }      
    }
