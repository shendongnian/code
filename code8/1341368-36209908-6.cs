    private void btnDeleteMovie_Click(object sender, EventArgs e)
    {
        movieSystem.DeleteMovie((Movie)(lstMovies.Items[0].Tag));
        lstMovies.Items.Remove(lstMovies.Items[0]);
    }
