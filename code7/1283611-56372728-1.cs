    private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Delete)
        {
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {
                cell.Value = "";
            }
            e.Handled = true;
        }
    }
