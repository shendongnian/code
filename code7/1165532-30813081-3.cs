    private void btnVowels_Click(object sender, EventArgs e)
    {
        string copyText = this.RemoveVowelsFromString(richTextBox1.Text);  
        richTextBox2.AppendText(copyText);
    }
    
    private void btnAlpha_Click(object sender, EventArgs e)
    {
        string copyText = richTextBox1.Text;
        string nonAlpha = @"[^A-Za-z ]+";
        string addSpace = "";
        copyText = Regex.Replace(copyText, nonAlpha, addSpace);
    
        // Remove the vowels from the RichTextBox1, then search for the vowel-less content in RichTextBox2.
        string vowelsOnly = this.RemoveVowelsFromString(richTextBox1.Text);
        int startingIndex = richTextBox2.Find(vowelsOnly);
             
        // Select the content to be replaced.
        richTextBox2.Select(startingIndex, vowelsOnly.Length);
            
        // Replace the content.
        richTextBox1.SelectedText = copyText;
    }
    private string RemoveVowelsFromString(string content)
    {
        string vowels = "AaEeIiOoUu";
        copyText = new string(copyText.Where(c => !vowels.Contains(c)).ToArray());
        return copyText;
    }
