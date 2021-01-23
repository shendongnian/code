    using (SqlConnection conn = new SqlConnection(dbConn))
            {
                using (SqlCommand cmd = new SqlCommand(spretrieve, conn))
                {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@param1", SqlDbType.VarChar).Value = selectedDATE;
                        cmd.Parameters.Add("@param2", SqlDbType.VarChar).Value = selectedLVL2RISK;
                        cmd.Parameters.Add("@param3", SqlDbType.VarChar).Value = selectedORSA;
                        cmd.Parameters.Add("@param4", SqlDbType.VarChar).Value = selectedDPT;
                        string query = cmd.CommandText;
                        foreach (SqlParameter p in cmd.Parameters)
                        {
                             query = query.Replace(p.ParameterName, p.Value.ToString());
                        }
                        //query variable store sql statement with parameter value.       
                        //Populate ORSA_ASSESSMENTS grid view
                        conn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        GRID.DataSource = ds.Tables[0];
                        GRID.DataBind();
              }
    }    
