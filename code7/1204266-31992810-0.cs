    using(var conn = new SqlConnection())
    using(var myCommand = new SqlCommand("SELECT persId, persName FROM Customers  WHERE persId = @persId", conn))
    {
        myCommand.Parameters.AddWithValue("@persId", persId);
        conn.Open();
        using(var rd = myCommand.ExecuteReader())
        {
            bool personExists = rd.HasRows;
            if(personExists)
            {
                // advance the reader to the first record, presuming there is only one, otherwise use a loop while(rd.Read)
                rd.Read();
                string persName = rd.GetString(1); // second field
                // ...
            }
            else
            {
                MessageBox.Show("The ID does not exist.");
            }
        }
    }
