     private void button2_Click(object sender, EventArgs e)
            {
                DataGridViewRow roow = new DataGridViewRow(); ;
                int rcnt = dataGridView1.Rows.Count - 2;
                int ccnt = dataGridView1.Rows[0].Cells.Count - 1;
                for (int i = 0; i <= rcnt; i++)
                {
                    roow = dataGridView1.Rows[i];
                    DataGridViewCheckBoxCell ischecked = roow.Cells[ccnt] as DataGridViewCheckBoxCell;
                    if ( (bool)ischecked.Value == true)
                    {
                        for (int j = 0; j <= ccnt; j++)
                        {
                            dataGridView1.Rows[rcnt].Cells[j].ReadOnly = true;
                        }
                    }
                    //ccnt--;
                }          
            }
