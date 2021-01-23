    private void CB1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string conn3str = <Connection String >;
            OleDbConnection conn3 = new OleDbConnection(conn3str); 
            // Pass the selected value from CB1 (string) equal to Table1.NM (string) but return the int ID.
            
		OleDbCommand tblRow2 = new OleDbCommand("select ID from Table1 where NM=  '"+ CB1.Text +"' ;" , conn3);
		try
        	{
			conn3.Open();
                	string r2 = Convert.ToString(tblRow2.ExecuteScalar());
                	MessageBox.Show(r2);
                	lblBTableID.Text = "ID Code= " + r2;
                	conn3.Close();
 		}
        	catch (Exception ex)
        	{
        		MessageBox.Show("Error  " + ex);
        	}
        }
