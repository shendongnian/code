    private void dataGridView1_CellValidating(object sender,
            DataGridViewCellValidatingEventArgs e)
        {
            // Validate the CompanyName entry by disallowing empty strings.
            if (dataGridView1.Columns[e.ColumnIndex].Name == "CompanyName")
            {
                if (String.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    dataGridView1.Rows[e.RowIndex].ErrorText =
                        "Company Name must not be empty";
                    e.Cancel = true;
                }
            }
        }
