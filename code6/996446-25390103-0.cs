    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var rptIdValue1 = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            foreach (DataGridViewRow r in dataGridView2.Rows)
            {
                if ((int)r.Cells[0].Value != rptIdValue1) continue;
                dataGridView2.Rows[r.Index].Selected = true;
                break;
            }
        }
