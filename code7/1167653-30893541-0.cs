    private void txtReadOnly_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.Handled = true;  // no ding for normal keys in the read-only!
            txtEdit.SelectionStart = txtReadOnly.SelectionStart;
            txtEdit.SelectionLength = txtReadOnly.SelectionLength;
        }
    }
