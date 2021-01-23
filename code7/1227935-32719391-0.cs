    public class SimplePropertyDescriptor<TComponent, TValue> : PropertyDescriptor
        where TComponent : class
    {
        private readonly Func<TComponent, TValue> getValue;
        private readonly Action<TComponent, TValue> setValue;
        private readonly string displayName;
        public SimplePropertyDescriptor(string name, Attribute[] attrs, Func<TComponent, TValue> getValue, Action<TComponent, TValue> setValue = null, string displayName = null)
            : base(name, attrs)
        {
            Debug.Assert(getValue != null);
            this.getValue = getValue;
            this.setValue = setValue;
            this.displayName = displayName;
        }
        public override string DisplayName { get { return displayName ?? base.DisplayName; } }
        public override Type ComponentType { get { return typeof(TComponent); } }
        public override bool IsReadOnly { get { return setValue == null; } }
        public override Type PropertyType { get { return typeof(TValue); } }
        public override bool CanResetValue(object component) { return false; }
        public override bool ShouldSerializeValue(object component) { return false; }
        public override void ResetValue(object component) { }
        public override object GetValue(object component) { return getValue((TComponent)component); }
        public override void SetValue(object component, object value) { setValue((TComponent)component, (TValue)value); }
    }
