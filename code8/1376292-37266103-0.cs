    private void buttonGo_Click(object sender, EventArgs e)
    {
    	string path = textBoxFileName.Text;
    	string s = string.Empty;
    	string[] parts;
    	using (StreamReader reader = new StreamReader(path, true))
    	{
    		parts = reader.ReadToEnd().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    	}
    
    	SaveFileDialog saveFileDialog = new SaveFileDialog();
    	saveFileDialog.ShowDialog();
    	string pathSave = saveFileDialog.FileName;
    
    	using (File.CreateText(pathSave))
    	{ }
    
    	using (StreamWriter sw = new StreamWriter(pathSave))
    	{
    		sw.Write(parts);
    	}
    }
