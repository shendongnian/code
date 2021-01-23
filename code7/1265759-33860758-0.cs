    private void richTextBox1_MouseUp(object sender, MouseEventArgs e)
    {
            RichTextBox box = (RichTextBox)sender;
            box.SelectionStart = box.GetCharIndexFromPosition(e.Location);
            box.SelectionLength = 0;
            // now read line / character as before
    }
