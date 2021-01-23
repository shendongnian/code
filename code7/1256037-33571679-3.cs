    private void button1_Click(object sender, EventArgs e)
            {
                ....
                DataRow dr;
                DataTable myDataTable = CreateMyTableDatasource();
                dr = myDataTable.NewRow();
                dr["col1"] = codeTextBox.Text;
                dr["col2"] = nameTextBox.Text;
                dr["col3"] = priceTextBox.Text;
                dr["col4"] = unitsTextBox.Text;
                myDataTable.Rows.Add(dr);
                tableDataGridView.DataSource = myDataTable;
                tableDataGridView.Refresh();
            }
