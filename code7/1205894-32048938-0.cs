    using System.Drawing.Design;
    ...
            [Editor(typeof(MyEditor), typeof(System.Drawing.Design.UITypeEditor))]
            public Collection<bool> Second {
                // etc...
            }
    
            private class MyEditor : UITypeEditor {
                public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) {
                    return UITypeEditorEditStyle.Modal;
                }
                public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value) {
                    var editor = new System.ComponentModel.Design.CollectionEditor(typeof(Collection<bool>));
                    var retval = (Collection<bool>)editor.EditValue(context, provider, value);
                    return new Collection<bool>(retval);
                    
                }
            }
