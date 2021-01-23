    public class YourCustomDataGridTextColumn : DataGridTextColumn
    {
    public delegate void ColumnTextChangedHandler(object sender,TextChangedEventArgs e);
    public event ColumnTextChangedHandler ColumnTextChanged;
        
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
            if (ColumnTextChanged != null) {
	                ColumnTextChanged(sender, e);
              }
    	}
    
    	#endregion    
    }
