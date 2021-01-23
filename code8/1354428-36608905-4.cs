    void editMBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)13)
        {
            editBox.Text = editMBox.Text;
            editMBox.Hide();
        }
    }
