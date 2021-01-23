private string id = string.Empty;
then my CellValueChanged method
private void dgvOggetto_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
// other code
            ID = dataGridView.Rows[dataGridView.CurrentCell.RowIndex].Cells["ID"].Value.ToString();
        }
and I used the SelectionChanged method
private void dgvOggetto_SelectionChanged(object sender, EventArgs e)
        {
// avoid fire the event if the Tag contains a keyword
            if (dataGridView.Tag.ToString().Contains("updating")) return;
            if (!string.IsNullOrEmpty(ID))
            {
//find the row
                DataGridViewRow row = dataGridView.Rows
                    .Cast<DataGridViewRow>()
                    .FirstOrDefault(r => r.Cells["ID"].Value.ToString().Equals(id));
                if (row != null)
                {
//select the row 
                    dataGridView.Rows[row.Index].Selected = true;
                    dataGridView.Rows[row.Index].Cells[0].Selected = true;
                    // place the current row in the middle
                    dataGridView.FirstDisplayedScrollingRowIndex = (row.Index - (dataGridView.Height - dataGridView.ColumnHeadersHeight) / dataGridView.RowTemplate.Height / 2) > 0 ? row.Index - (dataGridView.Height - dataGridView.ColumnHeadersHeight) / dataGridView.RowTemplate.Height / 2 : 0;
                }
// clean ID variable
                ID = string.Empty;
            }
        }
