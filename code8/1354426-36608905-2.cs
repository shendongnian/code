    void editBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        string sNew = editBox.Text.Substring(0, editBox.SelectionStart)
                + e.KeyChar + editBox.Text.Substring(editBox.SelectionStart);
        Console.WriteLine(sNew);
        e.Handled =  !validateMethod(sNew);
    }
