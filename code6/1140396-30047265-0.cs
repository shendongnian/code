        DataTable table = new DataTable();
        private void CalculatedFieldGrid_Load(object sender, EventArgs e)
        {
            table.Columns.Add("Name");
            table.Columns.Add("Count", typeof(int));
            table.Rows.Add();
            table.Rows[0][0] = "One";
            table.Rows[0][1] = 10;
            table.Rows.Add();
            table.Rows[1][0] = "Two";
            table.Rows[1][1] = 20;
            table.Rows.Add();
            table.Rows[2][0] = "Three";
            table.Rows[2][1] = 30;
            table.Rows.Add();
            table.Rows[3][0] = "Four";
            table.Rows[3][1] = 40;
            table.Rows.Add();
            table.Rows[4][0] = "Calculated Value: ";
            dataGridView1.DataSource = table;
            comboBox1.Items.Add("Add");
            comboBox1.Items.Add("Average");
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                table.Rows[4][1] = table.Compute("Sum(Count)", null);
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                table.Rows[4][1] = table.Compute("Avg(Count)", null);
            }
            dataGridView1.DataSource = table;
        }
