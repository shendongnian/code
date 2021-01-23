    using (OleDbConnection con = new OleDbConnection(connectionString))
    {
    	con.Open();
    	using (var cmd = new SqlCommand(
    	"insert into login ([user], [password]) values (@user, @pass);",
    	con))
    	{
    		cmd.Parameters.Add(new OleDbParameter("@user", textBox1.Text ));
    		cmd.Parameters.Add(new OleDbParameter("@pass", textBox1.Text ));
    
            if (temp > 0)
            {
                textBox1.Text = String.Empty;
                textBox2.Text = String.Empty;
                MessageBox.Show("Record Successfuly Added");
            }
            else
            {
                MessageBox.Show("Record Fail to Added");
            }
    	}
    }
