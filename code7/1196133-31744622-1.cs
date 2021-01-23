    DataTable dtYear = new DataTable();
    
    dtYear.Columns.Add("Year", typeof(int));   // add this line
    int Year1 = Convert.ToInt32(DateTime.Now.ToString("yyyy")); 
    for (i = 1980; i <=> Year1; i++)   
    {
       dtYear.Rows.Add(i); 
    } 
     ddlYear.DataSource = dtYear; 
     ddlYear.DataBind();
