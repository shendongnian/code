    public class MyUITypeEditor : UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, 
            IServiceProvider provider, object value)
        {
            //Just as an example, show a message box containing values from owner object
            var list = ((MyClass)context.Instance).SomeList;
            MessageBox.Show(string.Format("You can choose from {0}.",
                string.Join(",", list)));
            return base.EditValue(context, provider, value);
        }
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
    }
