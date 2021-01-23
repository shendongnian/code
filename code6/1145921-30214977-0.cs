    public void InvalidateCheckboxAppearance(CheckBox cb)
    {
       cb.Text = cb.Checked ? "B" : "1";
       cb.BackColor = cb.Checked ? Color.Green : BackColor;
    }
