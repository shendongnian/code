    protected void gvEmployee_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dt = GetRows();
        {
            string SortDir = string.Empty;
            if (dir == SortDirection.Ascending)
            {
                dir = SortDirection.Descending;
                SortDir = "Desc";
            }
            else
            {
                dir = SortDirection.Ascending;
                SortDir = "Asc";
            }
            DataView sortedView = new DataView(dt);
            sortedView.Sort = e.SortExpression + " " + SortDir;
            GridView1.DataSource = sortedView;
            GridView1.DataBind();
        }
    }
	 public void GridViewBind(DataTable dt){
		 GridView1.DataSource=dt;
         GridView1.DataBind();
	 }
     public DataTable GetRows()
    {
        var SQL = " SELECT * FROM doTAble; ";
        //You should use the "using" resource acquisition statement
        // http://www.dotnetperls.com/sqlconnection
		using(var conn=new OdbcConnection(ConfigurationManager.ConnectionStrings["cs"].ConnectionString))
        {
            conn.Open();
            var dadapter = new OdbcDataAdapter(SQL, conn);
            var dset = new DataSet();
            dadapter.Fill(dset);
            return dset.Tables[0];
       }
    }
