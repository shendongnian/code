        try
        {
            con.Open();
            if (MessageBox.Show("Do you really want to Insert these values?", "Confirm Insert", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Now the command text is no more built from pieces of 
                // of user input and it is a lot more clear
                SqlCommand cmd = new SqlCommand(@"insert INTO Table1 
                    (alpha1,alpha2,alpha3)  
                    VALUES (@a1, @a2, @a3)", con);
                // For every parameter placeholder add the respective parameter
                // and set the DbNull.Value when you need it
                cmd.Parameters.Add("@a1", SqlDbType.NVarChar).Value =
                    string.IsNullOrEmpty(comboBox_ConfacValue.Text) ? 
                                  DbNull.Value : comboBox_ConfacValue.Text);  
                cmd.Parameters.Add("@a2", SqlDbType.NVarChar).Value = 
                    string.IsNullOrEmpty(combobox_conversionDescription.Text ) ? 
                                  DbNull.Value : combobox_conversionDescription.Text );  
                cmd.Parameters.Add("@a3", SqlDbType.NVarChar).Value = 
                    string.IsNullOrEmpty(combobox_Description.Text ) ? 
                                  DbNull.Value : combobox_Description.Text );  
                // Run the command, no need to use all the infrastructure of
                // an SqlDataAdapter here....
                int rows = cmd.ExecuteNonQuery();
                // Check the number of rows added before message...
                if(rows > 0) MessageBox.Show("Inserted Successfully.");
