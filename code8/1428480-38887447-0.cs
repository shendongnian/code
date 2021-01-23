        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (Entities2 db = new Entities2())
            {
                int SID = Convert.ToInt32(cboSID.SelectedItem.ToString());
                int CID = Convert.ToInt32(cboCID.SelectedItem.ToString());  
                int got_marks = Convert.ToInt32(txtMark.Text);          
    
                Student_Course marks = db.Student_Course.Where(sc => sc.SID == SID && c.CID == CID ).FirstOrDefault();
                if( marks!= null ){
                  marks.Mark = got_marks;
                }else{
                   db.Student_Course.Add(new Student_Course{
                        SID = SID,
                        CID = CID,
                        Mark = got_marks
                   });
                  
                }
                
    
                db.SaveChanges();
                MessageBox.Show("Marks Added");
            }
    
            using (Entities2 db = new Entities2()) //link combobox and DataGridView to List in Student_Course
            {
                var studentCourse = from c in db.Student_Course select new { SID = c.SID, Mark = c.Mark };
    
                editDataGridView.DataSource = studentCourse.ToList();
            }
    
            using (Entities2 db = new Entities2())
            {
                var student = (from s in db.Students select s).ToList();
    
                cboSID.DisplayMember = "SID";
                cboSID.ValueMember = "SID";
                cboSID.DataSource = student;
            }
    
            using (Entities2 db = new Entities2())
            {
                var course = (from c in db.Courses select c).ToList();
    
                cboCID.DisplayMember = "CID";
                cboCID.ValueMember = "CID";
                cboCID.DataSource = course;
            }
        }
