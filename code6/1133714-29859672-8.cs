    private void cboFavorites_SelectedIndexChanged(object sender, EventArgs e)
    {
        var favorite = Favorite.GetFavorite(cboFavorites.Text);
        txtNotes.Text = favorite.Notes;
        txtAssetToolVersion.Text = favorite.AssesmentToolVersion;
        txtDbLocation.Text = favorite.DbLocation;
        chkNotesFromPlanner.Checked = favorite.NotesFromPlanner;
        txtProjectCodes.Text = favorite.ProjectCodes;
        cboProjects.SelectedText = favorite.Project;
        chkStraightToNew.Checked = favorite.StraightToNew;
    }
