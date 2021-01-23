    private void gvMarks_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
                int marks = Convert.ToInt32(gvMarks.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                int CIDref = Convert.ToInt32(gvMarks.Rows[e.RowIndex].Cells[0].Value);
                int SIDref = Convert.ToInt32(gvMarks.Rows[e.RowIndex].Cells[1].Value);
                if (marks <= 100 && marks >= 0)
                {
                    using (DataModel db = new DataModel())
                    {
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
