    public class MyType : ICustomTypeDescriptor
    {
        private string[] _properties;
        public MyType(string[] properties)
        {
            _properties = properties;
        }
        public AttributeCollection GetAttributes()
        {
            return null;
        }
        public string GetClassName()
        {
            return nameof(MyType);
        }
        public string GetComponentName()
        {
            throw new NotImplementedException();
        }
        public TypeConverter GetConverter()
        {
            return null;
        }
        public EventDescriptor GetDefaultEvent()
        {
            throw new NotImplementedException();
        }
        public PropertyDescriptor GetDefaultProperty()
        {
            return null;
        }
        public object GetEditor(Type editorBaseType)
        {
            return null;
        }
        public EventDescriptorCollection GetEvents()
        {
            throw new NotImplementedException();
        }
        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            throw new NotImplementedException();
        }
        public PropertyDescriptorCollection GetProperties()
        {
            return GetProperties(null);
        }
        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            var props = new PropertyDescriptor[_properties.Length];
            for (int i = 0; i < _properties.Length; i++)
                props[i] = new CustomPropertyDescriptor(_properties[i],
                    new Attribute[]
                    {
                        new DisplayNameAttribute(@"Displ Value " + i),
                        new CategoryAttribute("Category" + i%2)
                    });
            return new PropertyDescriptorCollection(props);
        }
        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }
    }
    public class CustomPropertyDescriptor : PropertyDescriptor
    {
        public CustomPropertyDescriptor(string name, Attribute[] attrs) : base(name, attrs)
        {
        }
        public override bool CanResetValue(object component)
        {
            return true;
        }
        public override object GetValue(object component)
        {
            return "1";
        }
        public override void ResetValue(object component)
        {
            throw new NotImplementedException();
        }
        public override void SetValue(object component, object value)
        {
            throw new NotImplementedException();
        }
        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }
        public override Type ComponentType { get; }
        public override bool IsReadOnly { get { return false; } }
        public override Type PropertyType { get { return typeof (string); } }
    }
