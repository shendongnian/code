    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Error != null) {
                //Handle error
            } else {
                IOBinding.DataSource = (DataTable)e.Result;
            }
    }
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
        using (SqlDataAdapter a = new SqlDataAdapter("SELECT Name,Value FROM dbo.IOData", c)) {
            DataTable IOProcData = new DataTable();
            // Populate data table
            a.Fill(IOProcData);
            // Record displayed row
            e.Result = a;
        }
    }
