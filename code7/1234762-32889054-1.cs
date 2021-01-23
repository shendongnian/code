    protected void AddJacket_Click(object sender, EventArgs e)
    {
        //Determine the RowIndex of the Row whose Button was clicked.
        int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;
        //Get the value of column from the DataKeys using the RowIndex.
        int id1 = Convert.ToInt32(GridViewSubjectList.DataKeys[rowIndex].Values[0]);
        int id2 = Convert.ToInt32(GridViewSubjectList.DataKeys[rowIndex].Values[1]);
        using (CADWEntities db = new CADWEntities())
        {
            var results = db.Subjects.SingleOrDefault(uu => uu.SubjectId == id1);
            results.JacketNumber = Convert.ToString(id2);
            db.SaveChanges();
        }
        //Hide the button after being click
        (sender as Control).Visible = false;
    }
