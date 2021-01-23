        DataTable dtProducts = new DataTable("ParcelInf");
        dtProducts.Columns.Add("Status");
        dtProducts.Columns.Add("Remarks");
        foreach (DataRow DR in dtProducts.Rows)
        {
            con.Open();
            UpdateQuery = "Update ParcelInf Set Status='" + DR["Status"] + "',Remarks='" + DR["Remarks"] + "' where RequestID=" + DR["RequestID"] ;
            cmd = new SqlCommand(UpdateQuery, con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
