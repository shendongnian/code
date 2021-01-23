            **To Retrieve & Display Data**
            `txtCnctNum.Text = "";
             txtAltCnctNum.Text = "";
             ...
             etc
            using (SqlConnection oSqlConnection = new SqlConnection("YourConnectionString"))
            {
                string strCommand = "Select * from YourTableName";
                SqlCommand oCmd = new SqlCommand(strCommand, oSqlConnection);
                oCmd.Parameters.AddWithValue("@CnctNum", CnctNum);
                oSqlConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        txtCnctNum.Text = oReader["CnctNum"].ToString();
                        txtAltCnctNum.Text = oReader["CnctNum"].ToString();
                        .....
                        etc
                    }
                    oSqlConnection.Close();
                }
            }`
