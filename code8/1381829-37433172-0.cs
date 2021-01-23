        private void button2_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < dataGridView1.RowCount; i++)
            {
                //Set defined value
                //dataGridView1.Rows[i].Cells["Column2"].Value = true;
                //toggle value from checked to unchecked.
                dataGridView1.Rows[i].Cells["Column2"].Value = !Convert.ToBoolean(dataGridView1.Rows[i].Cells["Column2"].Value);
            }
        }
