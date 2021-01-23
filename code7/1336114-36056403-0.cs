     private void Form1_Load(object sender, EventArgs e)
        {
            int a;
            String path1 = "Data Source=LOCALHOST; Initial Catalog= ss; username=root; password=''";
            MySqlConnection con = new MySqlConnection(path1);
            con.Open();
            string query = "Select Max(ID) from inc";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string val = dr[0].ToString();
               setText(val );
            }
    }
    
    
       private void button1_Click(object sender, EventArgs e)
        {
            String path = "Data Source=LOCALHOST; Initial Catalog= ss; username=root; password=''";
            MySqlConnection sqlconn = new MySqlConnection(path); //communicator //constructors
            MySqlCommand sqlcomm = new MySqlCommand();
            MySqlDataReader sqldr;
            sqlconn.Open();
            sqlcomm.Connection = sqlconn;
            sqlcomm.CommandType = CommandType.Text;
            sqlcomm.CommandText = "Select * from inc where ID=" + textBox1.Text + "";
    
            sqldr = sqlcomm.ExecuteReader();
            sqldr.Read();
    
            if (sqldr.HasRows)
            {
                textBox3.Text = sqldr[0].ToString();
    
            }
            sqlconn.Close();
    
    
            if (textBox1.Text == textBox3.Text)
            {
                MessageBox.Show("ID already exists!");
    
            }
    
            else
            {
                String path1 = "Data Source=LOCALHOST; Initial Catalog= ss; username=root; password=''";
                MySqlConnection sqlconnn = new MySqlConnection(path1); //communicator //constructors
                MySqlCommand sqlcommm = new MySqlCommand();
                sqlconnn.Open();
                sqlcommm.Connection = sqlconnn;
                sqlcommm.CommandType = CommandType.Text;
                sqlcommm.CommandText = "INSERT INTO inc (ID,Lastname) VALUES ("+ textBox1.Text +", '" + textBox2.Text + "')";
                sqlcommm.ExecuteNonQuery();
                sqlconnn.Close();
                MessageBox.Show("RECORD SAVED!");
               setText( textBox1.Text);
            }
        }
     private void setText(string newValue)
    {
        
                if (newValue == "")
                {
                    textBox1.Text = "1";
                }
                else
                {
                    a = Convert.ToInt32(newValue);
                    a = a + 1;
                    textBox1.Text = a.ToString();
                }
    }
