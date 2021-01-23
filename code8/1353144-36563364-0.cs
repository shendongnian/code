     private DataTable getSheetData(string strConn, string sheet)
        {
            //string sid = Convert.ToString(new SystemId());
            string Ctime = Convert.ToDateTime(DateTime.Now).ToString("yyyyMMddhhmmss");
            string Mtime = Convert.ToDateTime(DateTime.Now).ToString("yyyyMMddhhmmss");
            string actorSId = Convert.ToString(WebPage.CurrentSysUserSId);
            string query = "select * from [" + sheet + "]";
            OleDbConnection objConn;
            OleDbDataAdapter oleDA;
            DataTable dt = new DataTable();
            dt.Columns.Add("SID", typeof(string));
            dt.Columns.Add("CREATE_DATETIME", typeof(string));
            dt.Columns.Add("MODIFY_DATETIME", typeof(string));
            dt.Columns.Add("CREATOR_SID", typeof(string));
            dt.Columns.Add("MODIFIER_SID", typeof(string));
            dt.Columns.Add("MARK_DELETED", typeof(string));
            dt.Columns.Add("ENABLED", typeof(string));
            dt.Columns.Add("SORT", typeof(int));
    
            objConn = new OleDbConnection(strConn);
            objConn.Open();
            DataSet dataSet = new DataSet();
            oleDA = new OleDbDataAdapter(query, objConn);
            oleDA.Fill(dt);
            foreach (DataRow dr in dt.Rows) // search whole table
            {
                for (int i = 0; i < dt.Rows.Count - 1; i++)
                    if (dt.Rows.Count > i)
                    {
                        string sid = Convert.ToString(new SystemId());
                        var row = dt.Rows[i];
                        row["SID"] = sid;
                        row["CREATE_DATETIME"] = Ctime;
                        row["MODIFY_DATETIME"] = Mtime;
                        row["CREATOR_SID"] = actorSId;
                        row["MODIFIER_SID"] = 0;
                        row["MARK_DELETED"] = "N";
                        row["ENABLED"] = "Y";
                        row["SORT"] = 1;
                    }
            }
            objConn.Close();
            oleDA.Dispose();
            objConn.Dispose();
            return dt;
        }
