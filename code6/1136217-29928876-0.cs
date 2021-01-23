        try
        {
            
            SqlDataAdapter adap;
            DataSet ds;
            this.con = new SqlConnection();
            this.con.ConnectionString = (@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Duarte\Documents\Visual Studio 2013\Projects\WindowsFormsApplication2\WindowsFormsApplication2\PAPPloran.mdf;Integrated Security=True;Connect Timeout=30");
            this.con.Open();
            adap = new SqlDataAdapter("select * from Pagamentos", con);
            ds = new System.Data.DataSet();
            adap.Fill(ds, "P");
            dataGridView1.DataSource = ds.Tables[0];
        }
        catch(Exception ex)
        {
            MessageBox.Show("Erro\n" + ex.Message, "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
