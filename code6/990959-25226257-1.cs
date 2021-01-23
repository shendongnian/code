    private void button32_Click(object sender, EventArgs e) 
    {
            int index = richTextBox.SelectionStart - 1;
            if (richTextBox.Text.Length > 0 && index >= 0)
            {
                richTextBox.SelectionStart = index;
                richTextBox.Text = richTextBox.Text.Remove(index, 1);
                richTextBox.SelectionStart = index;
            }
            else
                MessageBox.Show("  Nothing to Undo  ");
            richTextBox.Focus();
    }
