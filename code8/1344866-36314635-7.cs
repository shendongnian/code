    public class MaskEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
        public override object EditValue(ITypeDescriptorContext context, 
                                         IServiceProvider provider, object value)
        {
            var field = context.Instance.GetType().GetField("maskedTextBox",
                           System.Reflection.BindingFlags.NonPublic | 
                           System.Reflection.BindingFlags.Instance);
            var maskedTextBox = (MaskedTextBox)field.GetValue(context.Instance);
            var maskProperty = TypeDescriptor.GetProperties(maskedTextBox)["Mask"];
            var tdc = new TypeDescriptionContext(maskedTextBox, maskProperty);
            var editor = (UITypeEditor)maskProperty.GetEditor(typeof(UITypeEditor));
            return editor.EditValue(tdc, provider, value);
        }
    }
