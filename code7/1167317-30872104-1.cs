    protected void btnSubmitCountParticipant_Click(object sender, EventArgs e)
    {
        try
        {
            var selectedParticipantCount = Convert.ToInt32(drpNoofparticipants.SelectedValue);
            var items = Enumerable.Repeat(string.Empty, selectedParticipantCount).ToList();
            ParticipantsGrid.DataSource = items;
            ParticipantsGrid.DataBind();
        }
        catch (Exception ex)
        { }
    }
    public void CreateControls()
    {
        try
        {
            var participants = ParticipantsGrid.Rows
                .Cast<GridViewRow>()
                .Select(row => ((TextBox)row.FindControl("txtNameofParticipant")).Text)
                .ToList();
        }
        catch (Exception ex)
        { }
    }
