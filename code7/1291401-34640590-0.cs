	private void button1_Click(object sender, EventArgs e)
	{
		BindingSource bs = (BindingSource)productsDataGridView.DataSource;
		bs.Filter = string.Format("SerialNumber Like  '%{0}%'", textBox1.Text);
		productsDataGridView.DataSource = bs;
	}
