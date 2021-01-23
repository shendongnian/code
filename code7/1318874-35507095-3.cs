    private void Students_Load(object sender, EventArgs e)
    {
        //Retrieving data from datbaser using LINQ class convert it to list students ID's
        var studentsList = DB.Students.ToList();
            
        //Databinding setup for the Student ID combo box
        cmbSTID.DisplayMember = "Name"; //Field name in Student class
        cmbSTID.ValueMember = "SID"; //Field name in Student class
        cmbSTID.DataSource = StudentIDs;
    }
