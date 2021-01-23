    List<string> list = new List<string>();
    list.Add("Ş\nŞ");
    list.Add("*Ş\nŞ");
    list.Add("Ş\nŞ");
    list.Add("*Ş\nŞ");
    for (int s = 0; s < list.Count; s++)
    {
        var diffColor = list.ElementAt(s)[0] == '*';
        var txtLength = richTextBox1.Text.Length;
        var myString = diffColor ? list.ElementAt(s).Substring(1, list.ElementAt(s).Length - 1) : list.ElementAt(s);
        richTextBox1.AppendText(myString);
        if (diffColor)
        {
            richTextBox1.SelectionStart = txtLength;
            richTextBox1.SelectionLength = myString.Length;
            richTextBox1.SelectionColor = Color.Red;
            richTextBox1.Select(0, 0);
        }
        if (s != list.Count - 1) richTextBox1.AppendText("\r\n\r\n");
    }
