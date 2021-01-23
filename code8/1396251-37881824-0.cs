    using (MySqlConnection SqlCon = new MySqlConnection(connStr))
    {
       MySqlDataReader myReader = null;
       using (MySqlCommand cmd = new MySqlCommand("SELECT S_Id, level FROM student where S_Id='" + 111 + "'"))
     {
      cmd.CommandType = CommandType.Text;
      cmd.Connection = SqlCon;
      SqlCon.Open();
      myReader = cmd.ExecuteReader();
      while (myReader.Read())
      {
       if (RadioButtonList1.Items.FindByValue(myReader["level"].ToString()) != null)
       {                           
         RadioButtonList1.SelectedValue = myReader["level"].ToString();
       }               
      }
      sqlCon.Close();
     }
    }
