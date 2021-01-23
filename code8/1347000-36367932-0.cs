    private void ModuleComboBox_SelectedIndexChanged(object sender, 
		System.EventArgs e)
	{
		// get the value (file path)
		string filePath = (string) ModuleComboBox.SelectedItem;
        if (File.Exists(filePath))
            richTextBox1.AppendText(File.ReadAllText(filePath));
        else
            RichBoxBox1.Clear();
	}
