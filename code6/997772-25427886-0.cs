    protected void GrdPerson_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Person person = (Person)e.Row.DataItem;
            GridView innerGrid = (GridView)e.Row.FindControl("GrdPersonAddresses");
            innerGrid.DataSource = person.Address;
            innerGrid.DataBind();
        }
    }
