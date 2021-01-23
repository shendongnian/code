    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        this.BindGrid();
        try
        {
    ... delete logic
            this.BindGrid(); // re-load after the change
        }
        catch (Exception ex)
        {
    ...
        }
    }
