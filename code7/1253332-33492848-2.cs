    Button btnEdit = Button as sender;
    GridViewRow gvr = (GridViewRow)btnEdit.NamingContainer;
    int rowindex = gvr.RowIndex;
    if (rowindex == GridView1.SelectedIndex)
    {
        gvr.BackColor = ColorTranslator.FromHtml("#A1DCF2");
    }
    else
    {
        gvr.BackColor = ColorTranslator.FromHtml("#FFFFFF");
    }
