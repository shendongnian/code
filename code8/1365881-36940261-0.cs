    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
    	var item = new ComboBox
    	{
    		Name = "subCat",
    		Location = new System.Drawing.Point(100, 71),
    		Width = 200,
    		Height = 21,
    		Text = "Choose SubCategori"
    	};
    	item.Items.Add("test1");
    
    	this.Controls.Add(item);
    	
    	// assign previously written method
    	item.SelectedIndexChanged += DynamicallyCreatedCombobox_SelectedIndexChanged;
    	// or
    	// assign created in place delegate
    	item.SelectedIndexChanged += (objSender, eventArgs) => {/* code here */};
    }
    
    // event handler for dynamically created combo box
    private void DynamicallyCreatedCombobox_SelectedIndexChanged(object sender, EventArgs e)
    {
    	// code here
    }
