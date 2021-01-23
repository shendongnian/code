                using (connection = new SqlConnection(sqlConnectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT ID,Name,PasswordSHA256, IsAdmin"
                + " From UsersTable", connection))
            {
                //get data
                DataTable user = new DataTable();
                adapter.Fill(user);
                usersTableDataGrid.DataContext = user;
            }
