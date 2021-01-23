      private void dataGridView1_DataError(object sender,
                DataGridViewDataErrorEventArgs e)
            {
                // If the data source raises an exception when a cell value is 
                // commited, display an error message.
                if (e.Exception != null &&
                    e.Context == DataGridViewDataErrorContexts.Commit)
                {
                    MessageBox.Show("");
                }
            }
    private void Form1_Load(object sender, EventArgs e)
        { dataGridView1.DataError +=
                    dataGridView1_DataError;}
