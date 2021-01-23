    private void SaveBtn_Click(object sender, EventArgs e)
    {
        SaveFileDialog enregistrercsv = new SaveFileDialog();
        enregistrercsv.Filter = "Fichier CSV (*.csv)|*.csv|All files (*.*)|*.*";
        if (enregistrercsv.ShowDialog() == DialogResult.OK)
        {
            using (StreamWriter writer = new StreamWriter(enregistrercsv.FileName)
    		{
                string strHeader = "";
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        strHeader += dataGridView1.Columns[i].HeaderText + ",";
                    }
	    				writer.WriteLine(strHeader);
		    			
                for (int m = 0; m < dataGridView1.Rows.Count; m++)
                {
                    string strRowValue = "";
                        for (int n = 0; n < dataGridView1.Columns.Count; n++)
                        {
                            strRowValue += dataGridView1.Rows[m].Cells[n].Value + ",";
                        }
                        
	    				writer.WriteLine(strHeader);
		    			
                }
            }
            MessageBox.Show("Fichier CSV créé avec succès FUCK YEAH");
        }
    }
