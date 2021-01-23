     if (dt.Rows.Count > 0)
            { 
           if(dt.Columns["permission"] == "Admin")
            {
             Response.Redirect("admin.aspx");
            }
            else
            {
             Response.Redirect("normal.aspx");
            }
    }
