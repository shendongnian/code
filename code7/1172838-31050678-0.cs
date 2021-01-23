        {
                   
            SqlConnection con = new SqlConnection("server = .\\SQLEXPRESS ; DataBase = Badban; Integrated Security 							= true");
           con.Open();
           
           
            SqlDataAdapter da = new SqlDataAdapter("SelectCement", con);
            SqlCommand com=new SqlCommand("SelectCement",con);
            com.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet dt = new DataSet();
            da.Fill(dt);
            for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
            {
                cmbCement.DroppedDown.Add(dt.Tables[0].Rows);
                cmbCement.ComboBox.DataSource = dt.Tables[0];
                cmbCement.ComboBox.ValueMember = "ID";
                cmbCement.ComboBox.Text = "Name";   
                
                con.Close();
            }
