    private void btnReplace_Click(object sender, EventArgs e)
    {
        MyReplace();
        MyMethod();
    }
    private void btnAlpha_Click(object sender, EventArgs e)
    {
        MyAlpha();
        MyMethod();
    }
    private void MyReplace()
    {
        // Replace code
    }
    private void MyAlpha()
    {
        // Alfa code
    }
    private void MyMethod()
    {
        //Replace code would go here…
        /*Count number of lines in processed text,
        extra line is always counted so -1 brings it to correct number*/
        int numLines = copyText.Split(“/n”).Length - 1;
            
        //seperate certain characters in order to find words
        char[] seperator = (" " + nl).ToCharArray();
            
        //number of words, characters and include extra line breaks variable
        int numberOfWords = copyText.Split(seperator, StringSplitOptions.RemoveEmptyEntries).Length;
        int numberOfChar = copyText.Length - numLines;
            
        //Unprocessed Summary
        newSummary = nl + "Word Count: " + numberOfWords + nl + "Characters Count: " + numberOfChar;
    }
