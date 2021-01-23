    void SaveButton_Click(object sender, EventArgs e)
    {
        var textBoxText = TextBox.Text;
    
        var lines = File.ReadAllLines(@"F:\Bioshock2SP.ini");
        
        using (var file = new StreamWriter(@"F:\Bioshock2SP.ini"))
        foreach(string line in lines)
        {
            if (line.Contains("VoVolume="))
                file.WriteLine(line.Substring(0, 9) + textBoxText); // Writes something like 'VoVolume=1.56'
            else file.WriteLine(line); // No editing required
        }
    
        MessageBox.Show("Setting saved!");
    }
