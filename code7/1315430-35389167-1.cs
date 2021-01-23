            if (button1.text == "1" && code == 1)//its a category
            {
                int i;
                i = dataGridView1.SelectedCells[0].RowIndex;
                textBox7.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                textBox6.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
                textBox3.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
                textBox8.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
                textBox9.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            }
            if (button2.text == "2" && code == 2)//another category
            {
                int i;
                i = dataGridView1.SelectedCells[0].RowIndex;
                textBox7.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                textBox6.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
                textBox3.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
                textBox9.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
           }
