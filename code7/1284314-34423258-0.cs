    private void ITemail()
    {
         string FinEmail;
         clsDBConnector dbConnector = new clsDBConnector();
         OleDbDataReader dr;
         dbConnector.Connect();
         var sqlStr = "SELECT Created, [Action], ConnectionLoc, ConnectionSystem, Resource, [Text], RecordId, ToVal, ClientName "
            + "FROM tblAudit WHERE (ClientName = '" + Client + "') AND Created = #" + ToDate() + "#";
         dr = dbConnector.DoSQL(sqlStr);
         while (dr.Read())
         {
             txtIT.Text = dr[0].ToString() + dr[1].ToString() + dr[2].ToString() + dr[3].ToString() + dr[4].ToString() + dr[5].ToString() + dr[6].ToString()
                    + dr[7].ToString() + dr[8].ToString();
         }
    }
    private string ToDate()
    {
        return DateTime.Today.ToString("yyyy'/'MM'/'dd");
    }
