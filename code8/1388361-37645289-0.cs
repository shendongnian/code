    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString))
         {
                String insert = "INSERT INTO [dbo].[Table] (Name,Surname,Email,Mobile,Telephone) VALUES (@name,@surname,@email,@mobile,@telephone)";
                SqlCommand command = new SqlCommand(insert, connection);
            
                command.Parameters.AddWithValue("@name", Name.Text);
                command.Parameters.AddWithValue("@surname", Surname.Text);
                command.Parameters.AddWithValue("@email", Email.Text);
                command.Parameters.AddWithValue("@mobile", Mobile.Text);
                command.Parameters.AddWithValue("@telephone", Telephone.Text);
                connection.Open();
                command.ExecuteNonQuery();
        }
