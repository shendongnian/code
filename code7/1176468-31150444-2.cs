    // Index
    int index = 0;
    // Loop over each line
    foreach (string line in richTextBox1.Lines)
    {
        // Ignore the non-assembly lines
        if (line.Substring(0, 2) != ";;")
        {
            // Start position
            int start = (richTextBox1.GetFirstCharIndexFromLine(index) + line.LastIndexOf(";") + 1);
            // Length
            int length = line.Substring(line.LastIndexOf(";"), (line.Length - (line.LastIndexOf(";")))).Length;
            // Make the selection
            richTextBox1.SelectionStart = start;
            richTextBox1.SelectionLength = length;
            // Change the colour
            richTextBox1.SelectionColor = Color.Red;
        }
        // Increase index
        index++;
    }
