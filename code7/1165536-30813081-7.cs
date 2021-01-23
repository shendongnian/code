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
    
        // Replace the content beneath the divider
        string divider = "------------";
        // Find the first char index of the divider line
        int dividerIndex = richTextBox2.Find(divider);
        // grab the line number that the divider is on
        int dividerLine = richTextBox2.GetLineFromCharIndex(dividerIndex);
        // get the first char on the line following the divider
        int startingIndex = richTextBox2.GetFirstCharIndexFromLine(dividerLine+1);
             
        // Select everything starting after the divider to be replaced.
        richTextBox2.Select(startingIndex, richTextBox2.Text.Length - startingIndex);
            
        // Replace the content.
        richTextBox1.SelectedText = copyText;
    }
    private string RemoveVowelsFromString(string content)
    {
        string vowels = "AaEeIiOoUu";
        copyText = new string(copyText.Where(c => !vowels.Contains(c)).ToArray());
        return copyText;
    }
