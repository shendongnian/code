    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        BindData();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        BindData();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int patientID = (int)e.Keys["patientID"]
        string surgery = (string)e.NewValues["surgery"];
        string location = (string)e.NewValues["location"];
        // Update here the database record for the selected patientID
        GridView1.EditIndex = -1;
        BindData();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int patientID = (int)e.Keys["patientID"]
        // Delete here the database record for the selected patientID
        BindData();
    }
