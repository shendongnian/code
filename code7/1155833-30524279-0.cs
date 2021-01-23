       private void dgrv_allkey_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
            {
                // Change Column Value for the DataGridView. 
                foreach (DataGridViewColumn i in
                    dataGridView1.Columns)
                {
                    if (i.Name == "key")
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            string oldvalue = row.Cells["key"].Value as string;
                            if (!string.IsNullOrEmpty(oldvalue))
                            {
                                // perform decoding here and set the decoded value here..
                            }
                            
                        }
                    }
                }
    
            }
