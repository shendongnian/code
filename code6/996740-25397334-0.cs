    if (!IsPostBack)
    {
        grid1.DataSource = versions.DefaultView;
        grid1.SelectedIndex = 0;
        grid1.DataBind();
        DataBindGridByIndex(0);
    }
    else
    {
        grid1.DataSource = versions.DefaultView;
        grid1.DataBind();
    }
    public void DataBindGridByIndex(int index)
    {
        // Logic to databind second grid by selected index.
    }
