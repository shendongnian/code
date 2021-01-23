    private void btnClear_Click(object sender, EventArgs e)
    {
       ClearTextBox(this);
    }
    void ClearTextBox (Control c)
    {
        var t = c as Textbox;
        if (t != null)
           t.Value = string.Empty;
        foreach (var child in c.Controls)
           ClearTextBox(child);
    }
