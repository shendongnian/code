    for(int i = 0; i < 2; i++){
      if (i = 0)
      {
        string tblnm = "Vehicle";
      }
      else
      {
        string tblnm = "Repairs";
      }
            SqlConnection conn;
            using (conn = new SqlConnection(connection))
            {
                conn.Open();           
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandText = @"IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES 
                       WHERE TABLE_NAME='" + tblnm + "') SELECT 1 ELSE SELECT 0"; ;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                int x = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
                if (x == 2)
                {
                    MessageBox.Show("Lentelės yra");
                }
                else
                {
                    MessageBox.Show("Lenteliu nėra.Sukuriama");
                }
    }
