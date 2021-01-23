    public class TypeSelector : UITypeEditor
    {
    	public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
    	{
    		if (context == null || context.Instance == null)
    			return base.GetEditStyle(context);
    
    		return UITypeEditorEditStyle.Modal;
    	}
    	public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
    	{
    		IWindowsFormsEditorService editorService;
    
    		if (context == null || context.Instance == null || provider == null)
    			return value;
    
    		editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
    
    		FormTypeSelector dlg = new FormTypeSelector();
    		dlg.Value = value;
    		dlg.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
    		if (editorService.ShowDialog(dlg) == System.Windows.Forms.DialogResult.OK)
    		{
    			return dlg.Value;
    		}
    		return value;
    	}
    }
