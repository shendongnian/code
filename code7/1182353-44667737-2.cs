    void FillAllitems(){
        using (SqlCeConnection cnt = new SqlCeConnection(@"Data Source=C:\com_honar\test1.sdf")) {
            cnt.Open();                                                                            // Open connection
            using (SqlCeDataAdapter at = new SqlCeDataAdapter("SELECT * FROM testi", cnt)){        // Create new DataAdapter
                var sqCB = new SqlCeCommandBuilder(at);
                DataTable tt = new DataTable();
                at.Fill(tt);                                                                   // Use DataAdapter to fill DataTable
                dataGridView2.DataSource = tt;                                                 // Render data onto the screen
            }
        }
    }
