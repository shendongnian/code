            ...
            sqlCmd.Parameters.Add("@startdate", SqlDbType.DateTime);
            sqlCmd.Parameters["@startdate"].Value = "06/01/2015 18:00:00";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd, sqlConn);
            DataTable tblOrder = new DataTable();
            adapter.Fill(tblOrder);
            // get the count
            // @TODO: This is a very expensive method -- there must be a better way
            int count = tblOrder.Rows.Count;
            ...
            grid1.DataSource = tblOrder;
            grid1.DataBind();
            ...
