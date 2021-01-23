    private void btnAlpha_Click(object sender, EventArgs e)
    {
        string nonAlpha = @"[^A-Za-z ]+";
        string addSpace = "";
        string copyText = richTextBox1.Text;
        copyText = Regex.Replace(copyText, nonAlpha, addSpace);
        WriteToFile(Second_File, wholeText);
    }
    
    private void btnVowels_Click(object sender, EventArgs e)
    {
        string vowels = "AaEeIiOoUu";
        string copyText = richTextBox1.Text;
        copyText = new string(copyText.Where(c => !vowels.Contains(c)).ToArray());
    
        string wholeText = richTextBox1.Text + copyText;
        WriteToFile(Second_File, wholeText);
    }
    
    private void WriteToFile(string filename, string contents)
    {
        if (File.Exists(filename))
        {
            File.WriteAllText(filename, contents);
            richTextBox2.Text = wholeText;
        }
        else
        {
            MessageBox.Show("No file named " + filename);
        }
    }
