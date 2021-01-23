    if (e.Row.RowState == DataControlRowState.Edit ||
        e.Row.RowState == DataControlRowState.Alternate)
    {
        TextBox txt = (TextBox)e.Row.FindControl("ID");
        txt.ReadOnly = true;
    }
