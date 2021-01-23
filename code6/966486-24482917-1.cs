    void dataGridView1_ColumnWidthChanged(object sender,
        DataGridViewColumnEventArgs e)
    {
        Properties.Settings.Default.Column1= dataGridView1.Columns[1].Width;
        // Set the width of every column of datagridview here
        Properties.Settings.Default.Save();// Save setting after setting all column width
    }
