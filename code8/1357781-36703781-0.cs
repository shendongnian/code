    private void GridView_SelectionChanged(object sender, EventArgs e)
    {
        DataGridViewRow dr = GridView.Rows[GridView.CurrentCell.RowIndex];
        id.Text = dr.Cells[0].Value.ToString();
        judul.Text = dr.Cells[1].Value.ToString();
        isi.Text = dr.Cells[2].Value.ToString();
    }
