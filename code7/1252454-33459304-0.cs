        private void btnSearch_Click(object sender, EventArgs e)
        {
            var conn = new SqlConnection();
            var dt = new DataTable();
            var SDA = new SqlDataAdapter("Select * from students where 
              studentId = " + txtSearch.Text, "Your connection string here");
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;            
        }
