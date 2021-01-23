      private void button1_Click(object sender, EventArgs e)
        {
            string firstColum = textBox1.Text;
            string secondColum = textBox2.Text;
            object[] row = { firstColum, secondColum };
            dataGridView1.Rows.Add(row);
        }
