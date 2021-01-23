     protected void Export_Click(object sender, EventArgs e)
    {
        DataTable dt = (DataTable)Session["datatable"];
        String names = (String)Session["names"];
        DataRow total = dt.Rows[dt.Rows.Count - 1]; //rreshti i fundit
        List<string> colSaved = new List<string>();
       
        for (int n = dt.Columns.Count-1; n >=0; n--)
        {
            
            if (total[n].ToString() != "0")  
                colSaved.Add(dt.Columns[n].ColumnName);
            
           
        }
    string[] columns = colSaved.ToArray();
       
    DataTable newTable;
    newTable = dt.DefaultView.ToTable(false, columns);
    StringBuilder sb = new StringBuilder();
      
    sb.AppendLine(string.Join(",",columns.Reverse()));
   
    foreach (DataRow r in newTable.Rows)
    {
       
             sb.AppendLine(string.Join(",", r.ItemArray.Reverse()));
    }
    string name = DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + DateTime.Now.Hour + "" + DateTime.Now.Minute + "" + DateTime.Now.Second + "" + DateTime.Now.Millisecond + "__" + ".csv";
    System.IO.File.WriteAllText(Server.MapPath("~/export/" + name), sb.ToString());
    Response.Redirect("~/export/" + name);
