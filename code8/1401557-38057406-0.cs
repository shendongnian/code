    private void RichtextBox1_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        // Determine whether the key entered is the F1 key. Display help if it is.
        if(e.KeyCode == Keys.OemPeriod)
        {
            RichTextBox1.Text += " ";
        }
    }
