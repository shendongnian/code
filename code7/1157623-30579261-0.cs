    String a = textBox1.Text;
    String result = String.Empty;
    String[] lines = a.Split(new String[] { Environment.NewLine }, StringSplitOptions.None);
    foreach(String line in lines.Reverse())
    {
        // inverse text
        foreach(char ch in line.Reverse())
        {
            result += ch;
        }
        // insert a new line
        result += Environment.NewLine;
    }
    // remove last NewLine
    result = result.Substring(0, result.Length - 1);
