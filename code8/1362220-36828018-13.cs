    // The RowEditing event is called when data editing has been requested by the user
    // The EditIndex property should be set to the row index to enter edit mode
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        BindData();
    }
    // The RowCancelingEdit event is called when editing is canceled by the user
    // The EditIndex property should be set to -1 to exit edit mode
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        BindData();
    }
    // The RowUpdating event is called when the Update command is selected by the user
    // The EditIndex property should be set to -1 to exit edit mode
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int patientID = (int)e.Keys["patientID"]
        string surgery = (string)e.NewValues["surgery"];
        string location = (string)e.NewValues["location"];
        // Update here the database record for the selected patientID
        GridView1.EditIndex = -1;
        BindData();
    }
    // The RowDeleting event is called when the Delete command is selected by the user
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int patientID = (int)e.Keys["patientID"]
        // Delete here the database record for the selected patientID
        BindData();
    }
