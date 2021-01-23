        private void btnadd_Click(object sender, EventArgs e)
        {
            String[] row = new String[7];
            dataGridView1.Rows[cnt].Cell[0].value = cmbsfno.SelectedItem.ToString();
            dataGridView1.Rows[cnt].Cell[1].value = cmbstandard.SelectedItem.ToString();
            dataGridView1.Rows[cnt].Cell[2].value = cmbprority.SelectedItem.ToString();
            dataGridView1.Rows[cnt].Cell[3].value = comboBox3.SelectedItem.ToString();
            dataGridView1.Rows[cnt].Cell[4].value = cmbpartfamily.SelectedItem.ToString();
            dataGridView1.Rows[cnt].Cell[5].value = comboBox2.SelectedItem.ToString();
            dataGridView1.Rows[cnt].Cell[6].value = txtremark.Text;
            dataGridView1.Rows.Add(row);
            cnt++;
        }
