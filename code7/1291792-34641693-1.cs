    DataTable dt = new DataTable();
    DataColumn dc = new Datacolumn("Provider");
    DataColumn dc1 = new Datacolumn("Collection");
    
    dt.columns.Add(dc);
    dt.columns.Add(dc1);
    
    DataRow dr = dt.NewRow();
    dr[dc] = ddlContent.SelectedValue;
    dr[dc1] = CheckInCollection(Convert.ToInt64(ddlContent.SelectedItem.Value));
    
    dt.Rows.Add(dr);
    gvData.DataSource = dt;
    gvData.DataBind();
