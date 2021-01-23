    private void SomeMethod()
    {
        string[] lines = GetFileNames();
    
        if (lines != null)
            textBox1.Lines = lines;
    }
    
    private string[] GetFileNames()
    {
        var dialog = new OpenFileDialog()
        {
            Multiselect = true
        };
    
        if (dialog.ShowDialog() == DialogResult.OK)
            return dialog.FileNames;
        else
            return null;
    }
