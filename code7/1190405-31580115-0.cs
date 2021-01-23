    try
    {
       string userName = UserNameTextbox.Text.Trim();
       using (SqlConnection conn = new SqlConnection("Your Conn String"))
       {
           string sql="select USERNAME from QuizTable where USERNAME=@USERNAME";
           using (SqlCommand command = new SqlCommand(sql,conn))
           {
              command.Parameters.AddWithValue("@USERNAME", userName );
              connection.Open();
              Object IsFound = command.ExecuteScalar();
              connection.Close();
              if (IsFound == null)
              {
                  //if not found
              }
              else
              {
                  //if found
              }
           }
        }
    }
    catch (Exception Ex)
    {
        MessageBox.Show(Ex.Message);
    }
