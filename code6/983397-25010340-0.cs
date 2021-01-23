     private void BindGridview()
    {
        string[,] arrlist = {
                        {"Suresh", "B.Tech"},
                        {"Nagaraju","MCA"},
                        {"Mahesh","MBA"},
                        {"Mahendra","B.Tech"}
                        };
        DataTable dt = new DataTable();
    	DataRow dr = null;
        dt.Columns.Add(new DataColumn("Name", typeof(string)));
        dt.Columns.Add(new DataColumn("Education", typeof(string)));
    	//dr = dt.NewRow();
        for (int i = 0; i < arrlist.GetLength(0);i++)
        {
            dr = dt.NewRow();
    		dr["Name"] = arrlist[i,0].ToString();
    		dr["Education"] = arrlist[i,1].ToString();
        }
    	gvarray.DataSource = dt;
        gvarray.DataBind();
    }
   
