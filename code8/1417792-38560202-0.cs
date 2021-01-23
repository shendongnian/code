    string ProductType = comboBoxProductType.Text;
            string ProductID = "Select ProductID from Productinformation where Name = '" + ProductType + "'";
            string query = "Insert into CustStoreProd (ProductID) VALUES (?ProductID)";
            MySqlCommand cmd = new MySqlCommand(ProductID, mySQLconnection);
    int pid = Convert.ToInt32(cmd.ExecuteScalar()); //assuming product id is integer
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("?ProductID", pid);
            cmd.ExecuteNonQuery();
