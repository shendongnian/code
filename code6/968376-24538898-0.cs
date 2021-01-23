    if(ddl.SelectedIndex > 0)
    {
        gridview.DataSource = filteredList;
        gridview.DataBind();
    }
    else
    {
        gridview.DataSource = unfilteredList;
        gridview.DataBind();
    }
