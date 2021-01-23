    string sql = @"UPDATE p4_projekt.customer_table 
                   set First_name=@firstname, Last_name=@lastname,
                       Email=@email,Password=@password
                   WHERE Customer_id=@id";
      MySqlCommand cmd = new MySqlCommand(sql, conn);
      cmd.Parameters.Add("@firstname", MySqlDbType.VarChar).Value = BoxFornavn.Text;
      cmd.Parameters.Add("@lastname, MySqlDbType.VarChar).Value = BoxEfternavn.Text;
      cmd.Parameters.Add("@email, MySqlDbType.VarChar).Value = textBoxEmail.Text;
      cmd.Parameters.Add("@password, MySqlDbType.VarChar).Value = BoxPawo.Text; 
      cmd.Parameters.Add("@id, MySqlDbType.Int32).Value =  ???? // no value for id ???
     
