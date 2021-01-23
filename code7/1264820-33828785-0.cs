    // suppress key only if you handled the keystroke
    void txtValue_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.SuppressKeyPress = true;
            if (IsModified)
                SaveData();
        }
        else if (e.KeyCode == Keys.Escape)
        {
            e.SuppressKeyPress = true;
            if (IsModified)
                ResetData();
        }
    }
