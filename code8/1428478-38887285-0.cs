    using (Entities2 db = new Entities2())
    {
     int SID = Convert.ToInt32(cboSID.SelectedValue);//Change this line
     int CID = Convert.ToInt32(cboCID.SelectedValue);//Change this line                
     Student_Course marks = (from c in db.Student_Course join s in db.Students on c.SID equals s.SID join o in db.Courses on c.CID equals o.CID where c.SID == SID && c.CID == CID select c).First();
     marks.Mark = Convert.ToInt32(txtMark.Text);
     //Delete this line db.SaveChanges();
     MessageBox.Show("Marks Added");
    }
