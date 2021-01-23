    if (MessageBox.Show("Confirm ?","DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
    {
        string name = dataGridView1.Rows[e.RowIndex].Cells[WHEREINDEX].Value.ToString();
        sql = "DELETE FROM [TABLE] WHERE [id] = " + dataGridView1.Rows[e.RowIndex].Cells[WHEREINDEX].Value.ToString();
        if (db.Exec(sql) > 0)
        {
            MessageBox.Show(name + " deleted");
            dtSummary.Rows.Find(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()).Delete();
            dataGridView1.Refresh();
        }
        else 
        {
            MessageBox.Show("error while deleting") 
        }
    }
