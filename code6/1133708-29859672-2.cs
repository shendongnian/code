    private void Form1_Load(object sender, EventArgs e)
    {
        // Get all saved favorites and load them up in the combo box
        this.Favorites = Favorite.GetFavorites();
        foreach (var name in Favorites.Select(fav => fav.Name))
        {
            cboFavorites.Items.Add(name);
        }
    }
