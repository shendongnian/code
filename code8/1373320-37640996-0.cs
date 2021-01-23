		protected void Button1_Click(object sender, EventArgs e)
        {
            string TabName = TextBox1.Text;
			
            string cmd = "Data Source=SQL5026;Initial Catalog=DB ...";
			
            int exists;
			
                SqlCommand check = new SqlCommand("select case when exists((select * from information_schema.tables where table_name = '" + TabName + "')) then 1 else 0 end",new SqlConnection (cmd));
				
                check.Connection.Open();
                exists = (int)check.ExecuteScalar();
                if (exists > 0)
                {
                    Label1.Text = "OK";
                }
                else
                {
                    Label1.Text = "NO";
                }
				}
