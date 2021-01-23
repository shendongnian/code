    public class MyPropertyDescriptor : PropertyDescriptor
    {
        private PropertyDescriptor subProperty;
        private PropertyDescriptor parentProperty;
        public MyPropertyDescriptor(PropertyDescriptor parent, PropertyDescriptor sub)
            : base(sub, null)
        {
            subProperty = sub;
            parentProperty = parent;
        }
        public override bool IsReadOnly { get { return subProperty.IsReadOnly; } }
        public override void ResetValue(object component)
        {
            subProperty.ResetValue(parentProperty.GetValue(component));
        }
        public override bool CanResetValue(object component)
        {
            return subProperty.CanResetValue(parentProperty.GetValue(component));
        }
        public override bool ShouldSerializeValue(object component)
        {
            return subProperty.ShouldSerializeValue(parentProperty.GetValue(component));
        }
        public override Type ComponentType { get { return parentProperty.ComponentType; } }
        public override Type PropertyType { get { return subProperty.PropertyType; } }
        public override object GetValue(object component)
        {
            return subProperty.GetValue(parentProperty.GetValue(component));
        }
        public override void SetValue(object component, object value)
        {
            subProperty.SetValue(parentProperty.GetValue(component), value);
            OnValueChanged(component, EventArgs.Empty);
        }
    }
