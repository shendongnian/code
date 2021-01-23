       private void showData()
        {
            string conString = @"your;connection;string;"
            SqlDataAdapter sda;
            DataTable dt;
            SqlConnection con = new SqlConnection(conString);
            sda = new SqlDataAdapter("SELECT * FROM yourTableName", con);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }
