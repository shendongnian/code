    public void BindMyGrid()
    {        
        string sortExpression = this.ViewState["SortExpression"].ToString();
        string sortDirection = this.ViewState["SortDirection"].ToString();
        string strsql = "SELECT * FROM [MasterTbl]  ORDER BY " + sortExpression + " " + sortDirection + "";
        MyDataSource.SelectCommand = strsql;
        MyGridView.DataSource = MyDataSource;
        MyGridView.DataBind();
    }
