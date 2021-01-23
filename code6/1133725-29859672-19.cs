    private void btnAddFavorite_Click(object sender, EventArgs e)
    {
        string favoriteName = cboFavorites.Text;
        if (string.IsNullOrEmpty(favoriteName))
        {
            MessageBox.Show("Please type a name for the favorite in the Favorites box.");
            return;
        }
        var favorite = new Favorite(favoriteName)
        {
            Notes = txtNotes.Text,
            AssesmentToolVersion = txtAssetToolVersion.Text,
            DbLocation = txtDbLocation.Text,
            NotesFromPlanner = chkNotesFromPlanner.Checked,
            ProjectCodes = txtProjectCodes.Text,
            Project = cboProjects.Text,
            StraightToNew = chkStraightToNew.Checked
        };
        favorite.Save();
        // If we're saving a new favorite, add it
        // to our global list and to the combo box
        if (Favorites.All(fav => fav.Name != favoriteName))
        {
            Favorites.Add(favorite);
            cboFavorites.Items.Add(favorite);
            cboFavorites.Text = favoriteName;
        }
    }
