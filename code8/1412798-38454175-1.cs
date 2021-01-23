    public class YourCustomDataGridTextColumn : DataGridTextColumn
    {
        
    	#region "Methods"
    
    	protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
    	{
    		var textBox = (TextBox)base.GenerateEditingElement(cell, dataItem);
    		textBox.TextChanged += OnTextChanged;
    		
    		return textBox;
    	}
        	
    	private void OnTextChanged(object sender, TextChangedEventArgs e)
    	{
    		//Your event handling
    	}
    
    	#endregion    
    }
