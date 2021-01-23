    public partial class CTextInput : UITableViewCell
    {
    	Action<string, string> OnTextFieldTextChanged;
    
    	public CustomCell ()
    	{
    	}
    
    	public CustomCell (IntPtr handle) : base (handle)
    	{
    	}
    
    	public void SetupCell (string labelText, string value, Action<string, string> onTextFieldTextChanged)
    	{
    		CellLabel.Text = labelText;
    		CellTextField.Text = value;
    		OnTextFieldTextChanged = onTextFieldTextChanged;
    
    		CellTextField.EditingDidEnd += HandleEditingDidEnd;
    	}
    
    	void HandleEditingDidEnd (object sender, EventArgs e)
    	{
    		var textField = sender as UITextField;
    		OnTextFieldTextChanged (CellLabel.Text, textField.Text);
    	}
    
    	// clean up
    	public override void PrepareForReuse ()
    	{
    		base.PrepareForReuse ();
    
    		OnTextFieldTextChanged = null;
    		CellTextField.EditingDidEnd -= HandleEditingDidEnd;
    	}
    
    	protected override void Dispose (bool disposing)
    	{
    		if (disposing) {
    			OnTextFieldTextChanged = null;
    		}
    
    		base.Dispose (disposing);
    
    	}
    
    }
