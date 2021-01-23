    private void dgvSMarks_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
        //    if (dgvSMarks.ContainsFocus == true)
        //    {
        //        // Get the RowIndex of the CID Cell, and add the combobox MCID value to it
        //        dgvSMarks.Rows[e.RowIndex-1].Cells[0].Value = Convert.ToInt32(cmbMCID.Text);
        //    }
            var student_course = new Student_Course();
            var course = new Course();
            //MessageBox.Show("Row Count is " + dgvSMarks.Rows.Count);
            for (int i = 1; i < dgvSMarks.Rows.Count; i++)
            {
                if (i == (dgvSMarks.Rows.Count - 1))
                {
                    student_course.CID = Convert.ToInt32(cmbMCID.Text);
                    student_course.SID = Convert.ToInt32(dgvSMarks.Rows[i - 1].Cells[1].Value);
                    student_course.Mark = Convert.ToInt32(dgvSMarks.Rows[i - 1].Cells[2].Value);
                    
                    DB.Student_Courses.InsertOnSubmit(student_course);
                    
                    DB.SubmitChanges();
                }
            }
        }
