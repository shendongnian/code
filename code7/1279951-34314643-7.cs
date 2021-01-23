    private void addNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(stud);
            f2.MdiParent = this;
            f2.StudentAdded+=ResponseToEvent;
            f2.Show();
        }
        void ResponseToEvent  (object sender,Student e)
     {
          List of Student. Add (  e);
    }
