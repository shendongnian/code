    public class MyDockEditor : UITypeEditor
    {
        DockEditor editor;
        public MyDockEditor()
        {
            editor = new System.Windows.Forms.Design.DockEditor();
        }
        public override object EditValue(ITypeDescriptorContext context, 
                                         IServiceProvider provider, object value)
        {
            Type dockUiType = typeof(DockEditor)
                   .GetNestedType("DockUI", BindingFlags.NonPublic);
            var dockUiConstructor = dockUiType.GetConstructors()[0];
            var dockUiField = typeof(DockEditor)
                   .GetField("dockUI", BindingFlags.Instance | BindingFlags.NonPublic);
            var dockUiObject = dockUiConstructor.Invoke(new[] { editor }) as Control;
            dockUiField.SetValue(editor, dockUiObject);
            var container = dockUiObject.Controls[0];
            var none = dockUiObject.Controls[1];
            var fill=  container.Controls[0];
            var left= container.Controls[1];
            var right= container.Controls[2];
            var top = container.Controls[3];
            var bottom = container.Controls[4];
            none.Enabled = false;
            fill.Enabled = false;
            top.Enabled = false;
            bottom.Enabled = false;
            return editor.EditValue(context, provider, value);
        }
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return editor.GetEditStyle(context);
        }
    }
