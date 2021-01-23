        string conString = string.Empty;
        try
        {
           conString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"].ToString();
        }
        catch(Exception)
        {
           MessageBox.Show("Unable to retrieve 'ConnectionString' from configuration file.");
        }
        string strSql = "select first_name + ' ' + last_name name, email from user_mst where mkey in (" + Session["UserId"].ToString() + ")";
        DataTable table = new DataTable();
        using (SqlConnection conn = new SqlConnection(conString))
        {
            conn.Open();
            using (SqlDataAdapter dbdata = new SqlDataAdapter(strSql, conn))
            {
                dbdata.Fill(table);
            }
            conn.Close();
        }
