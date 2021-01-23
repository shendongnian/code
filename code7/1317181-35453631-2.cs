     int JoNo;
     if(!Int32.TryParse(textBox10.Text, out JoNo))
     {
          MessageBox.Show("Not a valid number");
          return;
     }
     String check = @"IF EXISTS( SELECT 1 FROM Job WHERE JobNo=@num) 
                      SELECT 1 ELSE SELECT 0";
     using (SqlConnection con = new SqlConnection(str))
     using (SqlCommand cmd = new SqlCommand(check, con))
     {
         con.Open();
         cmd.Parameters.Add("@num", SqlDbType.Int).Value = JoNo;
         int result = (int)cmd.ExecuteScalar();
         if(result == 0)
              MessageBox.Show("No job number found, please try again!");
         else
              .....
      }
