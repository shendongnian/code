    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace Samples
    {
        // Generic implemenation of a property descriptor
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
        // Your stuff
        public abstract class PropertyPresentationSubBase : ICustomTypeDescriptor
        {
            public string GetClassName()
            {
                return TypeDescriptor.GetClassName(this, true);
            }
    
            public AttributeCollection GetAttributes()
            {
                return TypeDescriptor.GetAttributes(this, true);
            }
    
            public String GetComponentName()
            {
                return TypeDescriptor.GetComponentName(this, true);
            }
    
            public TypeConverter GetConverter()
            {
                return TypeDescriptor.GetConverter(this, true);
            }
    
            public EventDescriptor GetDefaultEvent()
            {
                return TypeDescriptor.GetDefaultEvent(this, true);
            }
    
            public PropertyDescriptor GetDefaultProperty()
            {
                return TypeDescriptor.GetDefaultProperty(this, true);
            }
    
            public object GetEditor(Type editorBaseType)
            {
                return TypeDescriptor.GetEditor(this, editorBaseType, true);
            }
    
            public EventDescriptorCollection GetEvents(Attribute[] attributes)
            {
                return TypeDescriptor.GetEvents(this, attributes, true);
            }
    
            public EventDescriptorCollection GetEvents()
            {
                return TypeDescriptor.GetEvents(this, true);
            }
    
            public virtual PropertyDescriptorCollection GetProperties(Attribute[] attributes)
            {
                PropertyDescriptorCollection rtn = TypeDescriptor.GetProperties(this);
    
                //rtn = FilterReadonly(rtn, attributes);
    
                return new PropertyDescriptorCollection(rtn.Cast<PropertyDescriptor>().ToArray());
            }
    
            public virtual PropertyDescriptorCollection GetProperties()
            {
    
                return TypeDescriptor.GetProperties(this, true);
    
            }
    
    
            public object GetPropertyOwner(PropertyDescriptor pd)
            {
                return this;
            }
    
            [Browsable(false)]
            public PropertyPresentationSubBase Parent
            {
                get
                {
                    return m_Parent;
                }
                set
                {
                    m_Parent = value;
                }
            }
    
            PropertyPresentationSubBase m_Parent = null;
    
            [Browsable(false)]
            public Type ValueType
            {
                get
                {
                    return valueType;
                }
                set
                {
                    valueType = value;
                }
            }
    
            private Type valueType = null;
    
            [Browsable(false)]
            public string Name
            {
                get
                {
                    return sName;
                }
                set
                {
                    sName = value;
                }
            }
    
    
    
            public abstract object GetValue();
    
            private string sName = string.Empty;
    
            public abstract void Change(object value);
        }
        public class QuadriFeatureItem
        {
            public QuadriFeatureItem(int featureId, string name)
            {
                m_featureId = featureId;
                m_name = name;
    
            }
            public int m_featureId;
    
            public string m_name;
        }
        class FeaturePropertyPresentation : PropertyPresentationSubBase
        {
    
            public int FeatureId
            {
                get
                {
                    return m_feature.m_featureId;
    
                }
                set { m_feature.m_featureId = value; }
            }
    
            public FeaturePropertyPresentation(QuadriFeatureItem item)
            {
                m_feature = item;
            }
    
            private QuadriFeatureItem m_feature;
    
            public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
            {
                var properties = base.GetProperties(attributes);
                // Custom name property
                properties.Add(new SimplePropertyDescriptor<FeaturePropertyPresentation, string>("FeatureName", attributes,
                    getValue: component => component.m_feature.m_name,
                    setValue: (component, value) => component.m_feature.m_name = value, // remove this line to make it readonly
                    displayName: "Feature Name"
                ));
                return properties;
            }
            public override void Change(object value)
            {
                throw new NotImplementedException();
            }
    
            public override object GetValue()
            {
                return this;
            }
    
        }
        // Test
        static class Test
        {
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                var dataSet = Enumerable.Range(1, 10).Select(n => new FeaturePropertyPresentation(new QuadriFeatureItem(n, "Nummer" + n))).ToList();
                var form = new Form();
                var dg = new DataGridView { Dock = DockStyle.Fill, Parent = form };
                dg.DataSource = dataSet;
                Application.Run(form);
            }
        }
    }
