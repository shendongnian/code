    class DynamicPerson : ICustomTypeDescriptor
    {
        public ObservableCollection<ColumnsValues> Features { get; } = new ObservableCollection<ColumnsValues>();
        #region  ICustomTypeDescriptor  
        private CustomTypeDescriptor _customTypeDescriptor = new DynamicPersonTypeDescriptor();
        public String GetClassName() => _customTypeDescriptor.GetClassName();
        public AttributeCollection GetAttributes() => _customTypeDescriptor.GetAttributes();
        public String GetComponentName() => _customTypeDescriptor.GetComponentName();
        public TypeConverter GetConverter() => _customTypeDescriptor.GetConverter();
        public EventDescriptor GetDefaultEvent() => _customTypeDescriptor.GetDefaultEvent();
        public PropertyDescriptor GetDefaultProperty() => _customTypeDescriptor.GetDefaultProperty();
        public object GetEditor(Type editorBaseType) => _customTypeDescriptor.GetEditor(editorBaseType);
        public EventDescriptorCollection GetEvents(Attribute[] attributes) => _customTypeDescriptor.GetEvents(attributes);
        public EventDescriptorCollection GetEvents() => _customTypeDescriptor.GetEvents();
        public object GetPropertyOwner(PropertyDescriptor pd) => this;
        public PropertyDescriptorCollection GetProperties(Attribute[] attributes) => GetProperties();
        public PropertyDescriptorCollection GetProperties()
        {
            var collectionDescriptors = Features.Select(x => new DynamicPersonPropertyDescriptor(Features, x)).ToArray(); 
            return new PropertyDescriptorCollection(collectionDescriptors);          
        }
        #endregion
        class DynamicPersonTypeDescriptor : CustomTypeDescriptor
        { }
        class DynamicPersonPropertyDescriptor : PropertyDescriptor
        {
            TypeConverter typeConverter;
            Collection<ColumnsValues> features;
            ColumnsValues feature;
            public DynamicPersonPropertyDescriptor(Collection<ColumnsValues> features, ColumnsValues feature)
                : base(feature.ColumnName, new Attribute[] { new BindableAttribute(true) })
            {
                this.features = features;
                this.feature = feature;
                typeConverter = TypeDescriptor.GetConverter(feature.Type);
            }
            public override Type ComponentType => feature.Type; 
            public override bool IsReadOnly => false;           
            public override Type PropertyType => feature.Type;  
            public override bool CanResetValue(object component) => true;
            public override object GetValue(object component) => typeConverter.ConvertFrom(feature.ValueOfColumn);
            public override void ResetValue(object component)
            {
                feature.ValueOfColumn = null;
            }
            public override void SetValue(object component, object value)
            {
                feature.ValueOfColumn = Convert.ToString(value);
            }
            public override bool ShouldSerializeValue(object component) => true;
        }
        public class ColumnsValues
        {
            public int IdProperty { get; set; }
            public string ColumnName { get; set; }
            public string ValueOfColumn { get; set; }
            public TypeCode TypeOfColumn { get; set; }
            public Type Type => Type.GetType("System." + TypeOfColumn);
        }
     }
