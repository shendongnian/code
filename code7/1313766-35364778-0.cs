    private void InitCombos()
    {
        Dictionary<string, int> items = GetItems();    
        combo.DisplayMember = "Key";
        combo.ValueMember = "Value";
        combo.DataSource = new BindingSource(items, null);
    }
    
    //This was where my problem was. I didn't set the two Member properties of my ComboBox, 
    //thus preventing correct rebinding of DataSource
    public void combo2_SelectedIndexChanged(object sender, EventArgs e)
    {
        combo.DataSource = null;
        Dictionary<string, int> newItems = GetItems();    
        combo.DisplayMember = "Key";
        combo.ValueMember = "Value";
        combo.DataSource = new BindingSource(items, null);
    }
