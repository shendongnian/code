    private void richTextBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if(e.Button == System.Windows.Forms.MouseButtons.Left)
        {
            label1.Text = richTextBox1.SelectedText;
        }
    }
    private void richTextBox1_SelectionChanged(object sender, EventArgs e)
    {
        label1.Text = richTextBox1.SelectedText;
    }
