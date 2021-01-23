    private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == dataGridView1.Columns["marks"].Index && e.RowIndex >= 0)
        {
            bool outOfRange;
            for (int j = 0; j < dataGridView1.RowCount; j++)
            {
                int value = int.Parse(dataGridView1.Rows[j].Cells["marks"].Value.toString())
                if ( value > 100 || value < 0)
                {
                    outOfRange = true;
                }
            }
            if(!outOfRange)
            {
                using (DataModel db = new DataModel())
                {
                    //sure that the code is correct?
                    Student_Course newMark = db.Student_Course.First(s => s.CID == CIDref && s.SID == SIDref);
                    newMark.Mark = marks;
                    db.SaveChanges();
                }
                MessageBox.Show("Marks updated");
            }
            else
            {
                MessageBox.Show("Out of Range");
            }
        }
    }
