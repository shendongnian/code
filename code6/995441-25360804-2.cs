    protected void GridView1_rowEditing(object sender, GridViewEditEventArgs e)
    {
    isInEditMode = true;
    GridView1.EditIndex = e.NewEditIndex;
    //rebind GridView1
    }
