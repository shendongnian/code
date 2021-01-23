    private void btnchoose_Click_1(object sender, EventArgs e)
    
    {
    
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Text files | *.csv";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string fileName;
                fileName = dlg.FileName;
                textBox2.Text = fileName;
            }
     private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtfileparth.Text != "")
            {
                string path = txtfileparth.Text;
                string userid = "";
                string password = "";
                string first_name = "";
                string last_name = "";
                string user_group = "";
    
                OleDbConnection my_con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0;");
                my_con.Open();
    
                OleDbCommand icmd = new OleDbCommand("SELECT * FROM [dataGridView1_Data$]", my_con);
    
                OleDbDataReader dr = icmd.ExecuteReader();
                while (dr.Read())
                {
                    userid = dr[0].ToString();
                    password = dr[1].ToString();
                    first_name = dr[2].ToString();
                    last_name = dr[3].ToString();
                    user_group = dr[4].ToString();
    
                    MySqlConnection con = new MySqlConnection("SERVER=***.**.***.****;" +
                        "DATABASE=dbs;" +
                        "UID=uid;" +
                        "PASSWORD=pws;");
                    con.Open();
    
                    MySqlCommand icmmd = new MySqlCommand("INSERT INTO aster_users(userid,password,first_name,last_name,user_group)VALUES(@a,@b,@c,@d,@e)", con);
                    icmmd.Parameters.AddWithValue("a", userid);
                    icmmd.Parameters.AddWithValue("b", password);
                    icmmd.Parameters.AddWithValue("c", first_name);
                    icmmd.Parameters.AddWithValue("d", last_name);
                    icmmd.Parameters.AddWithValue("e", user_group);
                    icmmd.ExecuteNonQuery();
                    con.Close();
                }
                MessageBox.Show("data Imported");
                txtfileparth.Text = "";
            }
            else if (txtfileparth.Text == "")
            {
    
            }
        }
