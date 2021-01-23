    private DataTable loadAdBusinessTypes1()
        {
            string prgInfoConnection = ConfigurationManager.ConnectionStrings["program_infoConnection"].ToString();
            SqlConnection oSqlConnection = new SqlConnection(prgInfoConnection);
            SqlCommand oSqlCommand = new SqlCommand("pGetAdBusinessTypes", oSqlConnection);
            oSqlCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            try{
                oSqlConnection.Open();
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                DataTable oDataTable1 = new DataTable("AdBusinessTypes");
                oSqlDataAdapter.Fill(oDataTable1);
                dt = oDataTable1;
            }
            catch(Exception ex){
                //you may work with exceptions here
            }
            finally{
                oSqlConnection.Close();
            }
            return dt;
        }
