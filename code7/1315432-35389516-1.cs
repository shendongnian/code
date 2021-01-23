    private void button1_Click(object sender, EventArgs e)
		{
			SqlDataAdapter sda = new SqlDataAdapter(@"Select * from Accessories", con);
			DataTable dt = new DataTable();
			sda.Fill(dt);
			dataGridView1.DataSource = dt;
			bool Button1Click = true;
		}
		bool Button1Click = false;
		bool Button2Click = false;
		private void button2_Click(object sender, EventArgs e)
		{
			/////another category
			bool Button2Click = true;
		}
		private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (button1.text == "1" && Button1Click)//its a category
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
			if (button2.text == "2" && Button2Click)//another category
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
		}
