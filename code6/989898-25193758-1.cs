    private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                if (r.Cells["status"].Value.ToString() == "Online")
                {
                   //add image here
                }
            }
    }
