    private void richTextBox1_TextChanged(object sender, EventArgs e)
    {
        if (richTextBox1.Text.Contains("{"))
        {
            richTextBox1.AppendText(Environment.NewLine + "    "); // line 1
            int lastIndex = richTextBox1.Text.Length - 1;
            richTextBox1.AppendText(Environment.NewLine + "}"); // line 2
            richTextBox1.SelectionStart = lastIndex;
            richTextBox1.SelectionLength = 0;
        }
    }
