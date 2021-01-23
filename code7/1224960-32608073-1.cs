    private void save_Click(object sender, EventArgs e)
    {
    	ACCOUNT.oo.Open();
    	string QRY = "insert into size(SIZENO,SIZE,COVERAGE,WEIGHT) values(?,?,?,?)";
    	using(OleDbCommand ODB = new OleDbCommand(QRY, ACCOUNT.oo))
    	{
    		ODB.Parameters.Add(size_id.Text);
    		ODB.Parameters.Add(txt_size.Text);
    		ODB.Parameters.Add(txt_coverage.Text);
    		ODB.Parameters.Add(txt_weight.Text);
    		ODB.ExecuteNonQuery();
    	}
    	MessageBox.Show("Inserted Sucessfully..");
    	ACCOUNT.oo.Close();
    }
