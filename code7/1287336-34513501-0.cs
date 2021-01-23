       private int shiftNumbers(int number, int newNumber) 
        {
            //int newNumber = 0;
            string stm = "UPDATE devices SET number= @newNumber WHERE number>@number";
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                cmd = new MySqlCommand(stm, con);
                    SqlParameter paramNumber = new SqlParameter("@number", SqlDbType.Int);
                    paramNumber.Value = number;
                   SqlParameter paramNewNumber = new SqlParameter("@newNumber", SqlDbType.Int);
                   paramNewNumber.Value = newNumber;
                   cmd.Parameters.Add(paramNumber);
                   cmd.Parameters.Add(paramNewNumber);
                con.Open();
                cmd.ExecuteNonQuery();   
            }
      //Rest of your code logic if any
       }
