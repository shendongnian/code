    private void BindData()
    {
        OleDbConnection conn = new OleDbConnection();
        conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Documents and Settings\IT1\My Documents\Downloads\examples\demo1\kk.accdb";
        conn.Open();
        
        string sql = "Select * from Category3 Where CategoryID IN (Select CategoryID from Product3)";
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        OleDbDataAdapter ad=new OleDbDataAdapter(cmd);
        DataSet ds=new DataSet();
        ad.Fill(ds, "Category3");
        ad.Dispose();
        
        sql = "Select p.PID,p.ImageName,p.ImageUrl,p.VideoName,p.VideoSize,p.CategoryID from Product3 p";
        cmd.CommandText = sql;
        ad=new OleDbDataAdapter(cmd);
        ad.Fill(ds, "Product3");
        ad.Dispose();
        
        ds.Relations.Add(new DataRelation("CategoriesRelation",ds.Tables[0].Columns["CategoryID"],
        ds.Tables[1].Columns["CategoryID"]));
        outerRep.DataSource=ds.Tables[0];
        outerRep.DataBind();
     }
