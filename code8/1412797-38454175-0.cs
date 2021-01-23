    public class YourCustomDataGridTextColumn : DataGridTextColumn
    {
        
    	#region "Methods"
    
    	protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
    	{
    		var textBox = (TextBox)base.GenerateEditingElement(cell, dataItem);
    		textBox.TextChanged += OnTextChanged;
    		
    		return textBox;
    	}
    
    	protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
    	{
    		dynamic CellControl = base.GenerateElement(cell, dataItem);
    
    		CellControl.Style = DefaultElementStyle;
    
    		Binding bind = GetBinding(dataItem, StringFormat: null, ConverterCulture: null, Converter: null, ConverterParamenter: null);
    		CellControl.SetBinding(TextBlock.TextProperty, bind);
    
    		return CellControl;
    	}
    	
    	private void OnTextChanged(object sender, TextChangedEventArgs e)
    	{
    		//Your event handling
    	}
    
    	#endregion    
    }
