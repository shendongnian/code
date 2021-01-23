    private void btnLoadChart_Click(object sender, EventArgs e)
        {
            charRejections.Series["RFR"].Points.Clear();
            {
                string connectiontring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\Database1.mdb";
                DataConnection = new OleDbConnection(connectiontring);
                try
                {
                    DataConnection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = DataConnection;
                    string query = "SELECT COUNT(reject_category) as reject, reject_category FROM tblReject_test GROUP BY reject_category";
                    command.CommandText = query;
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        charRejections.Series["RFR"].Points.AddXY(reader["reject_category"].ToString(), reader["reject"].ToString());
                    }
                    DataConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
            } 
        }//end of load chart button
