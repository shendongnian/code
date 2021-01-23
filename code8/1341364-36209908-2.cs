    private void btnDeleteMovie_Click(object sender, EventArgs e)
    {
        lstMovies.Items.Remove(lstMovies.Items[0]);
        movieSystem.DeleteMovie((Movie)(lstMovies.Items[0].Tag));
    }
