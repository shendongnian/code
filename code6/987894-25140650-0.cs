    private void button1_Click(object sender, EventArgs e)
    {
        const string path = "C:\\Users\\Ben\\Documents\\CreateDirectoryTest\\";
    
        var directory = System.IO.Path.Combine(path, Searchbox.Text);
    
        if (!Directory.Exists(directory)) 
        {
            Directory.CreateDirectory(directory); 
        }
    }
