    DataTable dt = querytodbHere_Return_DataTable; 
     DropDownList lst = new DropDownList();
     foreach (DataRow drow in dt.Rows)
       {
        lst = (DGGeneric.Rows[cnt].Cells[0].FindControl("drpaction") as DropDownList);
        lst.Items.Add(new ListItem("--Select Action--"));
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
         lst.Items.Add(new ListItem(dr[1].ToString()));                              
        }    
         cnt += 1;
      }
