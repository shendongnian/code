    // Create data table to be filled
    var DT = new DataTable();
    DT.Columns.Add("Num", typeof(int));
    DT.Columns.Add("Name");
    DT.Columns.Add("Phone");
    DT.Columns.Add("CellPhone");
    
    ...
    
    int i = 0;
    foreach (var item in moduleItems)
    {
        i++;
    
        DataRow Row = DT.NewRow();
        Row["Num"] = i;
        Row["Name"] = item.Name;
        Row["Email"] = item.Email;
    
        if (roleId == 5)
        {
            Row["Phone"] = item.Phone;
            Row["CellPhone"] = item.CellPhone;
        }
    
        DT.Rows.Add(Row);
    }
    
    ...
    
    // instantiate a datagrid
    GridView dg = new GridView();
    
    dg.DataSource = DT.DefaultView;
    dg.DataBind();
    dg.RenderControl(htw);
    response.Write(sw.ToString());
    response.End();
