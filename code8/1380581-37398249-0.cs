    private void textBox3_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Space &&
                            ((e.Modifiers & Keys.Shift) != 0) &&
            ((e.Modifiers & Keys.Control) != 0))  
        {
            char nbrsp = (char)160;        // non-breaking space
            char slimnbrsp = (char)239;   // slim non-breaking space
            int s = textBox3.SelectionStart;
            textBox3.Text = textBox3.Text.Insert(s, nbrsp.ToString());
            e.Handled = true;
            textBox3.SelectionStart = s + 1;
        }
    }
