    public void Sort(IList<ListItem> items, SortDirection direction)
    {
        var dataTable = ToDataTable(items);
        var dataView = new DataView(dataTable);
        dataView.Sort = string.Format("{0} {1}", "Text",
            direction == SortDirection.Ascending ? "ASC" : "DESC");
        GridView1.DataSource = dataView;
        GridView1.DataBind();
    }
