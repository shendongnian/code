        dynamic foo = this.GetPropertyInfo();
        string i = foo.MyPropertyName;
        private ExpandoObject GetPropertyInfo()
        {
            dynamic obj = new ExpandoObject();
            obj.PropertyName = "MyPropertyName";
            obj.PropertyType = "MyPropertyType";
            return obj;
        }
