    private void button1_Click(object sender, EventArgs e)
        {
            Database1Entities db = new Database1Entities();
    
            var st = new Student { StudentName = "Jack" };
    
            db.Students.Add(st);
            db.SaveChanges();
    
            foreach (Student s in db.Students)
                listBox1.Items.Add(s.StudentName);
        }
