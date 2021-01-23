    private void button32_Click(object sender, EventArgs e) 
    {
        int index = richTextBox.SelectionStart - 1;
        if (index > 0)
        {
            richTextBox.SelectionStart = index;
            if (richTextBox.Text.Length < 1) MessageBox.Show("  Nothing to Undo  ");
    
                //Otherwise, delete character when button press, (one character at a time).
            else
    
                richTextBox.Text = richTextBox.Text.Remove(index, 1);
            richTextBox.SelectionStart = index; // This line will retain the cursor 
                                                // position after removing the character
            richTextBox.Focus();
        }
    }
