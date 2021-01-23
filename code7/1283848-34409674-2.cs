            try
            {
    
                dataGridView1.ClearSelection();   //or restore rows backcolor to default
                for (int i = 0; i < (dataGridView1.Rows.Count); i++)
                {
                    for (int j = 0; j < (dataGridView1.Columns.Count); j++ )
                        if ((dataGridView1.Rows[i].Cells[j].Value.ToString().StartsWith(txbSearchName.Text, true, CultureInfo.InvariantCulture)) == false)
                            //(dataGridView1.Rows[i].Cells[j].Value.ToString().StartsWith(txbSearchName.Text, true, CultureInfo.InvariantCulture))
                        {
                            //dataGridView1.FirstDisplayedScrollingRowIndex = i;
                            //dataGridView1.Rows[i].Selected = true; //It is also possible to color the row backgroud
                            //return;
                            dataGridView1.Rows.Remove(dataGridView1.Rows[i]);
                        }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("not exist");
            }
