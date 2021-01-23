        public void BindData1()
        {
            using (SqlConnection con = new SqlConnection("your Connection String"))
            {
                con.Open();
                string query = "select CountryName from Countries";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter d = new SqlDataAdapter(query, con);
                DataSet dt = new DataSet();
                d.Fill(dt);
                if (dt.Tables[0].Rows.Count > 0)
                {
                    comboBox1.DataSource = dt.Tables[0];
                    //comboBox1.ValueMember = "CountryName";
                    comboBox1.DisplayMember = "CountryName";
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("No Countries found");
                }
                
            }
        }
