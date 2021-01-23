    private MyField _first;
    [MyAttribute("This is the first")]
    public MyField First {
        get { return _first; }
        set {
            _first = value;
            if (_first != null) {
                _first.SomeAttribute = GetMyAttributeValue("First");
            }
        }
     }
     private string GetMyAttributeValue(string propName)
     {
         PropertyInfo pi = this.GetType().GetPropertyInfo(propName);
         if (pi == null) return null;
         Object[] attrs = pi.GetCustomAttributes(typeof(MyAttribute));
         MyAttribute attr =  attrs.Length > 0 ? attrs[0] as MyAttribute : null;
         return attr != null ? attr.Value : null;
     }
    
