    protected void caseloads_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = caseloads.DataSource as DataTable;
        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataTable = dataView.ToTable();
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);
        caseloads.DataSource = dataView;
        caseloads.DataBind();
        }
    }
