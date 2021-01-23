    [System.Web.Services.WebMethod ,System.Web.Script.Services.ScriptMethodAttribute()] 
    public static List<string> GetNames(string name)
    { 
         List<string> nameList = new List<string>();
         string strSqlQuery = "Select * from SubRegions where SubRegionName like '%" + name + "%'";
         SqlDataAdapter da = new SqlDataAdapter(strSqlQuery, Common.GetConnectionString());
         DataSet ds = new DataSet(); da.Fill(ds, "SubRegions");
         DataTable dt = ds.Tables["SubRegions"]; 
         DataRowCollection drc = dt.Rows; 
         foreach (DataRow dr in drc)
         {
             nameList.Add(dr["SubRegionName"].ToString()); 
         } 
         return nameList; 
    }
 
