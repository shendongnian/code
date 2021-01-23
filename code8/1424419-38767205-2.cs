            //Firstly reset your control like below
            `txtCnctNum.Text = "";
             txtAltCnctNum.Text = "";
             ...
             etc
            // Then Use This Code to To Retrieve & Display Data
            using (SqlConnection oSqlConnection = new SqlConnection("YourConnectionString"))
            {
                string strCommand = "Select * from YourTableName where CnctNum=@CnctNum";
                SqlCommand oCmd = new SqlCommand(strCommand, oSqlConnection);
                oSqlConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        txtCnctNum.Text = oReader["CnctNum"].ToString();
                        txtAltCnctNum.Text = oReader["AltCnct"].ToString();
                        .....
                        etc
                    }
                    oSqlConnection.Close();
                }
            }`
