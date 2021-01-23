    IList<string> selectedValues= new List<string>();
    foreach (Control control in placeHolderText.Controls)
    {
    	if (control is TextBox)
    	{
    		var textBox = control as TextBox;
    		selectedValues.Add(textBox.Text);
    	}
    }
