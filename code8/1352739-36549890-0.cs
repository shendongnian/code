    if(dataTable.Rows.Count == 0)
    {
      FixGridFooter(dataTable);
    }
    else
    {
       GridView1.DataSource = datatable;
       GridView1.DataBind();
    }
    private void FixGridFooter(DataTable dataSource)
    {
        //add blank row to the the resultset
        dataSource.Rows.Add(dataSource.NewRow());
        dataSource.Rows[0]["Value1"] = 0;
        dataSource.Rows[0]["Value2"] = "";
        dataSource.Rows[0]["RecordDate"] = DateTime.Now.ToString("dd MMM yyyy");
        dataSource.Rows[0]["Checked"] = false;
        GridView1.DataSource = dataSource;
        GridView1.DataBind();
    
        //hide empty row - if you want to display it on an event like a button click else it will display as per default.
        //GridView1.Rows[0].Visible = false;
     }
