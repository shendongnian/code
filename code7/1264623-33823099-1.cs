    using (SqlConnection cons = new SqlConnection(constr))
    {           
       cons.Open();
       using (SqlCommand cmds = new SqlCommand(query))
       {                   
          using (SqlDataAdapter sda = new SqlDataAdapter())
          {
             cmds.CommandType = CommandType.Text;
             cmds.Connection = cons;
             sda.SelectCommand = cmds;
             **sda.Fill(dt);** //Error occurs here
          }
       }
       return dt;
    }
