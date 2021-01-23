    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        foreach (Control ctrl in e.Row.Controls)
        {
            MakeTextboxesReadonly(ctrl);
        }
    }
    private static void MakeTextboxesReadonly(Control parent)
    {
        foreach (Control ctrl in parent.Controls)
        {
            if (ctrl is TextBox)
            {
                (ctrl as TextBox).Enabled = false;
            }
        }
    }
