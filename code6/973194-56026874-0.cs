    private void Object_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.E && e.Alt)
        {
            e.SuppressKeyPress = true;
        }
    }
    private void Object_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.E && e.Alt)
        {
            e.SuppressKeyPress = true;
            EditRecord();  // This opens a form for the editing process
        }
    }
