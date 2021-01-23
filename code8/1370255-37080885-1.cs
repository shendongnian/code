    private void button1_Click(object sender, EventArgs e)
    {
        int selectionStart = 0;
        foreach (var item in richTextBox1.Text.Split(' '))
        {
            Color rgb = Color.FromName(item);
            richTextBox1.SelectionStart = selectionStart;
            richTextBox1.SelectionLength = item.Length;
            richTextBox1.SelectionColor = rgb;
            selectionStart += item.Length + 1;
        }
    
    }
