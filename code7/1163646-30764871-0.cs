        public DataTable getKit(SqlConnection connection, string itemNumber)
        {
            DataTable dt = new DataTable();
            SqlConnection myConnection = connection;
            MessageBox.Show(myConnection.ConnectionString);
            SqlParameter paramItemNumber = new SqlParameter();
            paramItemNumber.ParameterName = "@ItemNumber";
            paramItemNumber.Value = itemNumber;
            paramItemNumber.SqlDbType = System.Data.SqlDbType.VarChar;
            try
            {
                string sql =
    @"SELECT    kits.Row_Id, 
		    kits.Kit_Item_Number, 
		    kits.Location_Code		
    FROM	Macola_SWW.dbo.Z_PV_Kits kits 
    WHERE kits.Kit_Item_Number=@ItemNumber 
    ";
                //myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(sql, myConnection))
                {
                    myCommand.Parameters.Add(paramItemNumber);
                    SqlDataReader reader = myCommand.ExecuteReader();
                    dt.Load(reader);
                }
            }
            catch (Exception ex)
            {
                dt = null;
                MessageBox.Show(ex.ToString());
            }
            return dt;
        }
