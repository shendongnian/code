    var n = 5;
    for (int i = 1; i <= n; i++)
    {
        for (int j = 1; j <= n; j++)
        {
            this.richTextBox1.AppendText(string.Format("{0,3}", i * j));
        }
        this.richTextBox1.AppendText(Environment.NewLine);
    }
