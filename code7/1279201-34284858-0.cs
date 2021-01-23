     private void textBox2_TextChanged(object sender, EventArgs e)
            {
                SqlConnection conn = new SqlConnection("Data Source=SUMIT;Initial Catalog=Project;Integrated Security=True " + "connection timeout=300");
                conn.Open();
                 
                string query = "Select * from Product where product_Name  like '%"+textBox2.Text+"%'";
                SqlDataAdapter a = new SqlDataAdapter(query,conn);
                DataTable b = new DataTable();
                a.Fill(b);
                dataGridView1.DataSource = b;
    
            }
