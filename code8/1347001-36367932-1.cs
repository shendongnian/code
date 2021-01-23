    private void ModuleComboBox_SelectedIndexChanged(object sender, 
		System.EventArgs e)
	{
		// get the value (file path)
		string fileName = (string) ModuleComboBox.SelectedItem;
        string filePath = Path.Combine(@"C:\Modules\", fileName + ".txt");         
        if (File.Exists(filePath))
            richTextBox1.AppendText(File.ReadAllText(filePath));
        else
            RichBoxBox1.Clear();
	}
