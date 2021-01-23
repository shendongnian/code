    var dt = new DataTable();
    dt.Columns.Add("ID", typeof(string));
    dt.Columns.Add("Group", typeof(string));
    dt.Columns.Add("Value", typeof(string));
    
    foreach (GridViewRow row in gvDetails.Rows)
    {
           var dro = dt.NewRow();
           dro["ID"] = ((Label)row.FindControl("lblID")).Text;
           dro["Group"] = ((Label)row.FindControl("lblGrp")).Text;
           dro["Value"] = ((TextBox)row.FindControl("txtValue")).Text;
     
           dt.Rows.Add(dro);
    }
