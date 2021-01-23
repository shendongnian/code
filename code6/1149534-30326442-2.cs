    private void btnSubmit_Click(object sender, EventArgs e)
    {
    	//traverse all Tab Pages
    	foreach (TabPage tabpage in tabControl1.Controls.OfType<TabPage>())
    	{
    		foreach (TextBox txtbox in tabpage.Controls.OfType<TextBox>())
    			textBox_Validating(txtbox, null);
    
    		foreach (ComboBox combo in tabpage.Controls.OfType<ComboBox>())
    			comboBox_Validating(combo, null);
    
    		foreach (DateTimePicker date in tabpage.Controls.OfType<DateTimePicker>())
    			dateTimePicker1_Validating(date, null);
    	}
    
    	if (IsValidated)
    		MessageBox.Show("submitted");
    	else
    		MessageBox.Show("not submitted");
    }
