    private void comboBox_SelectedIndexChanged(object sender, 
		System.EventArgs e)
    {
	ComboBox comboBox = (ComboBox) sender;
        string entryName = (string) comboBox.SelectedItem;
        //retrieve the values from the dictionary using the value of 'entryName'.
        List values = new List<int>();
        if (valueComboMapping.TryGetValue(entryName, out values)
        {
            //do something if the key is found.
        }
        else
        {
            //do something else if the key isn't found in the dictionary.
        }
