    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;       
            System.Data.OleDb.OleDbConnection con = new System.Data.OleDb.OleDbConnection();
            con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\dhelm.ALLMATINC.001\Desktop\Db11.accdb";
            cmd.CommandText = @"insert into Table1 (Customer,Description,Color,Status) VALUES('" + tBox3.Text + "','" + tBox1.Text + "','" + tBox12.Text + "','" + cBox2.Text + "')";
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            System.Windows.Forms.MessageBox.Show("Recrod Succefully Created");
            con.Close();
        }
        catch(Exception ex)
        { 
            MessageBox.Show("error " + ex); 
        }
    }
