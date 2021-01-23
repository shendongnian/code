        SqlConnection c = new SqlConnection();
        private void Form1_Load(object sender, EventArgs e)
        {
            if (c.State == ConnectionState.Closed)
            {
                c.Open();
            }            
        }
