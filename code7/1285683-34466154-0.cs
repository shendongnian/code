    private void richTextBox1_SelectionChanged(object sender, EventArgs e)
    {
        int currentIndex = richTextBox1.SelectionStart;
        // Get the line number of the cursor.
        Ln = richTextBox1.GetLineFromCharIndex(currentIndex);
        // Get the index of the first char in the specific line.
        int firstLineCharIndex = richTextBox1.GetFirstCharIndexFromLine(Ln);
        // Get the column number of the cursor.
        Col = currentIndex - firstLineCharIndex;
        // The found indices are 0 based, so add +1 to get the desired number.
        toolStripStatusLabel1.Text = "Col:" + (Col + 1) + "   Ln:" + (Ln + 1);
    }
