    int start = 0;
    private void richTextBox1_MouseDown(object sender, MouseEventArgs e)
    {
        start = richTextBox1.GetTrueIndexPositionFromPoint(e.Location);
        richTextBox1.SelectionStart = start;
    }
    private void richTextBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button.HasFlag(MouseButtons.Left))
        {
            var current = richTextBox1.GetTrueIndexPositionFromPoint(e.Location);
            richTextBox1.SelectionStart = Math.Min(current, start);
            richTextBox1.SelectionLength = Math.Abs(current - start);
        }
    }
