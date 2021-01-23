    private void button3_Click(object sender, EventArgs e)
    {
        string cs = "provider = microsoft.ace.oledb.12.0; Data Source=C:\\Users\\Obm\\Desktop\\Emp.accdb; ";
        OleDbConnection conn = new OleDbConnection(cs);
        conn.Open();
        string q1 = "select username,password,usertype from MyUser where username = '" + textBox1.Text + "'and password = '" + textBox2.Text + "'";
        OleDbCommand cmd = new OleDbCommand(q1, conn);
        OleDbDataReader reader = cmd.ExecuteReader();
        while(reader.Read() )
        {
             MessageBox.Show("Success");
             string usertype = reader.GetString(2);
             //do something with usertype, eg if(usertype == "admin")...
         }
         reader.Close();
         conn.Close();
    }
