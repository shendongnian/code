            SqlConnection cnn = null;
            SqlCommand cmd = null;
            SqlDataAdapter sda = null;
            DataTable Dt = new Datatable();
          
            cnn = new SqlConnection(strConnectionString);
            cmd = new SqlCommand("Select COLUMN FROM WHEREVER WHERE VALUE =@TextboxValue", cnn);
            cnn.Open();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@TextboxValue", SqlDbType.VarChar).Value = Textbox.Text;
            sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
           if (dt.rows.count > 0 ) 
            {
               //MATCH FOUND
            }
               
