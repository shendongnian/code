    private void button1_Click_1(object sender, EventArgs e)
    {
        // Normally you might prompt the user for a Favorites name using a
        // custom input box: string favoriteName = InputBox("Add a Favorite");
        string favoriteName = "My Favorite";
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
            cboFavorites.Items.Add(favoriteName);
            cboFavorites.Text = favoriteName;
        }
    }
