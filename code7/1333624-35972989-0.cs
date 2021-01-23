    private void button1_Click(object sender, EventArgs e)
    {
        using(SqlConnection conn = new SqlConnection()) 
        {
           conn.ConnectionString = "your connection_string";
           conn.Open();
           
          // Create the command
          SqlCommand command = new SqlCommand("select * from table where Nev= @firstParmeter and Jelszo= @secondParameter", conn);
          // Add the parameters.
          command.Parameters.Add(new SqlParameter("firstParmeter", textBox1.Text));
          command.Parameters.Add(new SqlParameter("secondParameter", textBox2.Text));
        
          // Create new SqlDataReader object and read data from the command.
          using (SqlDataReader reader = command.ExecuteReader())
          {
            // while there is another record present
            while (reader.Read())
            {
                // set what you want here as it will be reading all the rows from the query example below
                // write the data on to the screen
                Console.WriteLine(String.Format("{0} \t | {1} \t | {2} \t | {3}",
                // call the objects from their index
                reader[0], reader[1], reader[2], reader[3]));
                
            }
          }
        }
    }
