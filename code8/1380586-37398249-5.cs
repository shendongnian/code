    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Space &&
            ModifierKeys == Keys.Control)
        {
            char nbrsp = '\u2007';             // non-breaking space
            char zerospace = '\u200B';         // zero space
            char zerospacebinding = '\u200D';  // zero space with binding
            int s = textBox1.SelectionStart;
            textBox1.Text = textBox1.Text.Insert(s, nbrsp.ToString() );
            e.Handled = true;
            textBox1.SelectionStart = s + 1;
        }
    }
