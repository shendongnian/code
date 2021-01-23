    public void sume()
        {
            int sum1 = 0;
            int sum2 = 0;
            int sum3 = 0;
            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {
                if (label17.Text.Length != 0)
                {
                    sum1 += (Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value));                    
                }
                if (label18.Text.Length != 0)
                {
                    sum2+= (Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value));                    
                }
                if(label19.Text.Length != 0)
                {
                   sum3+= (Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value));                   
                }
            }
			
			sum1 += Convert.ToInt32(label17.Text);
			sum2 += Convert.ToInt32(label18.Text);
			sum3 += Convert.ToInt32(label19.Text);
			label17.Text = sum1.ToString();
			label18.Text = sum2.ToString();
			label19.Text = sum3.ToString();
            MessageBox.Show("done");
        }
