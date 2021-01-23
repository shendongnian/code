    string copyText = null;  //added
    private void newSummaryMethod() {
         copyText = ""; //changed
    
         /*Count number of lines in processed text,
    extra line is always counted so -1 brings it to correct number*/
         int numLines = copyText.Split('\n').Length - 1;
    
         //seperate certain characters in order to find words
         char[] seperator = (" " + nl).ToCharArray();
    
         //number of words, characters and include extra line breaks variable
         int numberOfWords = copyText.Split(seperator, StringSplitOptions.RemoveEmptyEntries).Length;
         int numberOfChar = copyText.Length - numLines;
    
         //Unprocessed Summary
         newSummary = nl + "Word Count: " + numberOfWords + nl + "Characters Count: " + numberOfChar;
     }
    
     private void btnVowels_Click(object sender, EventArgs e) {
         //Strip vowels
         string vowels = "AaEeIiOoUu";
         copyText = richTextBox1.Text; //changed
         copyText = new string(copyText.Where(c => !vowels.Contains(c)).ToArray());
    
         newSummaryMethod();
    
         //Write into richTextBox2
         wholeText = richTextBox1.Text + oldSummary + copyText + newSummary;
         Write(Second_File, wholeText);
         richTextBox2.Text = wholeText;
     }
    
     private void btnAlpha_Click(object sender, EventArgs e) {
    
         //Remove non alpha characters
         string nonAlpha = @"[^A-Za-z ]+";
         string addSpace = "";
         copyText = richTextBox1.Text; //changed
         copyText = Regex.Replace(copyText, nonAlpha, addSpace);
    
         newSummaryMethod();
    
         //Write into richTextBox2
         wholeText = richTextBox1.Text + oldSummary + copyText + nl + newSummary;
         Write(Second_File, wholeText);
         richTextBox2.Text = wholeText;
    
     }
