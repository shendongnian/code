            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Image,Name from UserInput where PINCODE = '" + txt_LPin.Text + "'",conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
