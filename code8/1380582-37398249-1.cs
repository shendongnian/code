    private void textBox3_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Space &&
                            ((e.Modifiers & Keys.Shift) != 0) &&
            ((e.Modifiers & Keys.Control) != 0))  
        {
            char nbrsp = '\u2007';  // non-breaking space
            char zerospacebinding = '\u200D';  // zero space with binding
            int s = textBox3.SelectionStart;
            textBox3.Text = textBox3.Text.Insert(s, nbrsp.ToString());
            e.Handled = true;
            textBox3.SelectionStart = s + 1;
        }
    }
