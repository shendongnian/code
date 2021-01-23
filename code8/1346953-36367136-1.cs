    using MySql.Data.MySqlClient;
    using System.Data;
    MySqlConnection dbconn = new MySqlConnection("SERVER=;PORT=;DATABASE=;UID=;PWD=;");
    
        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * from MyTable", dbconn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            dbconn.Open();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(ds);
            dt = ds.Tables[0];
    
            foreach (DataRow dr in dt.Rows)
            {
                listBox1.Items.Add(dr["YOUR COLUMN NAME HERE"].ToString());
            }
            dbconn.Close();
        }
