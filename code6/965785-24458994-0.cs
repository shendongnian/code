            SqlConnection sqlCon = new SqlConnection("REMOVED");
            sqlCon.Open(); 
  
            SqlCommand sqlCmd = new SqlCommand(
                "Select * from products.products", sqlCon);
            SqlDataReader reader = sqlCmd.ExecuteReader();
            string fileName = "test.csv";
            StreamWriter sw = new StreamWriter(fileName);
            object[] output = new object[reader.FieldCount];
            for (int i = 0; i < reader.FieldCount; i++)
                output[i] = reader.GetName(i);
            sw.WriteLine(string.Join(",", output));
            while (reader.Read())
            {
                reader.GetValues(output);
                sw.WriteLine(string.Join(",", output));
            }
            sw.Close();
            reader.Close();
            sqlCon.Close();
