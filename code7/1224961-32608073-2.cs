    private void save_Click(object sender, EventArgs e)
    {
    	ACCOUNT.oo.Open();
    	string QRY = "insert into size(SIZENO,SIZE,COVERAGE,WEIGHT) values(?,?,?,?)";
    	using(OleDbCommand ODB = new OleDbCommand(QRY, ACCOUNT.oo))
    	{
            // change the OleDbType based on your actual data types
    		ODB.Parameters.Add("SIZENO", OleDbType.Integer).Value = int.Parse(size_id.Text);
    		ODB.Parameters.Add("SIZE", OleDbType.Integer).Value = int.Parse(txt_size.Text);
    		ODB.Parameters.Add("COVERAGE", OleDbType.Integer).Value = int.Parse(txt_coverage.Text);
    		ODB.Parameters.Add("WEIGHT", OleDbType.Integer).Value = int.Parse(txt_weight.Text);
    		ODB.ExecuteNonQuery();
    	}
    	MessageBox.Show("Inserted Sucessfully..");
    	ACCOUNT.oo.Close();
    }
