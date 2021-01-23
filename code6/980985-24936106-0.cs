    private void Hide_or_Show(object sender, EventArgs e)
    {
    Table table = (Table)button.Parent.Parent.Parent;
    for (int i = 1; i < table.Rows.Count; i++)
        {
            table.Rows[i].Visible = !table.Rows[i].Visible;
        }
    }
