    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    
    [Designer(typeof(MyControlDesigner))]
    public partial class MyControl: Control
    {
    }
    
    public class MyControlDesigner : ControlDesigner
    {
        public override void InitializeNewComponent(System.Collections.IDictionary defaultValues)
        {
            base.InitializeNewComponent(defaultValues);
            PropertyDescriptor descriptor = TypeDescriptor.GetProperties(base.Component)["Text"];
            if (((descriptor != null) && (descriptor.PropertyType == typeof(string))) && (!descriptor.IsReadOnly && descriptor.IsBrowsable))
            {
                descriptor.SetValue(base.Component, string.Empty);
            }
        }
    }
