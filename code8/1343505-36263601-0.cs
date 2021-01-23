    // First, split your text as lines:
	var lines = richTextBox1.Text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
    // Then, check just the second line (since in your example you are only interested in the second line):
    if(lines.Length > 1)
    {
        if(lines[1].Contains("hello!")
        {
            // do things
        }
    }
