    string message = "";
    string countItemSelected = "";
    int count = 0;
    foreach (ListItem item in cmbEmp_Name.Items)
    {
        if (item.Selected)
        {
            if (count > 0)
                message += ",";
            count++;
            message += item.Value;
            countItemSelected = item.Value;
            //Muster_Process();
        }
    }
    
    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + message + "');", true);
