    private void textBox5_TextChanged(object sender, EventArgs e)
            {
                // Your gridViews here
                var gridList = new List<DataGridView>() { yourGrid1, yourGrid2};
                foreach(DataGridView dv in gridList)
                {
                    dv.RowFilter = string.Format("Prece LIKE '%{0}%'", textBox5.Text);
                    dataGridView1.DataSource = dv;
                }
            }
