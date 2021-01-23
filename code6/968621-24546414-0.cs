      [CategoryAttribute("Base"), DescriptionAttribute("The font")]
      [Editor(typeof(MyFontEditor), typeof(UITypeEditor))]
      public Font Font
      {
          get;
          set;
      }
      ...
    
      public class MyFontEditor : UITypeEditor
      {
          public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
          {
              return UITypeEditorEditStyle.Modal;
          }
    
          public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
          {
              FontDialog dlg = new FontDialog();
              dlg = new FontDialog();
              dlg.MaxSize = 8;
              dlg.MinSize = 8;
    
              Font font = value as Font;
              if (font != null)
              {
                  dlg.Font = font;
              }
    
              if (dlg.ShowDialog() == DialogResult.OK)
                  return dlg.Font;
    
              return base.EditValue(context, provider, value);
          }
      }
