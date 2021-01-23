        private void button1_Click(object sender, EventArgs e) 
          {
            string cs = "Data Source=ServerName; Initial Catalog=DatabaseName; Integrated Security=SSPI;";
            string sql = "Your query goes here, i.e the info that you want to display in your ComboBox";
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql,con);
            try
               {
                 con.Open();                 
                 Dataset ds = new DataSet();
                 ds.tables[0].rows.add(TextBox1.Text);
                 dataAdapter.update(ds);
                 ComboBox1.datasource = ds;
               } 
            finally
               {
                 con.Close();
               }
           }
