    private void richTextBox1_MouseUp(object sender, MouseEventArgs e)
    {
            RichTextBox box = (RichTextBox)sender;
            Point mouseLocation = new Point(e.X, e.Y);
            box.SelectionStart = box.GetCharIndexFromPosition(mouseLocation);
            box.SelectionLength = 0;
            // now read line / character as before
    }
