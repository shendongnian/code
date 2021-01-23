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
        // When saving a favorite, add it to the combo box
        // (remove the old one first if it already existed)
        var existingFav = cboFavorites.Items.Cast<Favorite>()
            .FirstOrDefault(fav => fav.Name == favoriteName);
        if (existingFav != null)
        {
            cboFavorites.Items.Remove(existingFav);
        }
        cboFavorites.Items.Add(favorite);
        cboFavorites.Text = favoriteName;
    }
