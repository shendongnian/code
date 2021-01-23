    using (var cnx = new SqlConnection(connectionString)) {
        cnx.Open();
        var sql = @"insert into beforebath1 (first_name, second_name)
                    values (@fname, @lname)";
        using (var cmd = new SqlCommand(sql, cnx)) {
            cmd.Parameters.AddWithValue("@fname", fname_tb.Text);
            cmd.Parameters.AddWithValue("@lname", lname_tb.Text);
            
            try {
                int rowsAffected = cmd.ExecuteNonQuery();
                if (0 < rowsAffected) MessageBox.Show("Success!");
                else MessageBox.Show("Failed!");
            } catch (SqlException ex) {
                // It is almost prefered to let the exception be thrown freely
                // so that you may have its full stack trace and have more 
                // details on your error.
                MessageBox.Show(ex.Message);
            } finally {
                if (cnx.State == ConnectionState.Open) cnx.Close();
            }
        }
    }
