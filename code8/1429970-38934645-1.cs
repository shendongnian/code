    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.comboBox1.SelectedValue == null)
            return;
        var desiredColumns = new[] { "Price", "Name" };
        var id = (int)this.comboBox1.SelectedValue;
        var data = db.Product.Where(x => x.CategoryId == id).ToList();
        dataGridView1.DataSource = data;
        dataGridView1.Columns.Cast<DataGridViewColumn>()
                     .Where(x => !desiredColumns.Contains(x.DataPropertyName))
                     .ToList().ForEach(x => { x.Visible = false; });
    }
