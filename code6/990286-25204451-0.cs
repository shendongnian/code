    void dataGridView1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Tab &&
            dataGridView1.SelectedCells
                         .Cast<DataGridViewCell>()
                         .Any(x => x.ColumnIndex == 6))
        {
            e.Handled = true;
        }
    }
