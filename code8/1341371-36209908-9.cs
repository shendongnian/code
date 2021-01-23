    private void btnAddMovie_Click(object sender, EventArgs e)
    {
        Movie movie = movieSystem.AddMovie(txtTitle.Text, txtGenre.Text, txtActor.Text, txtYear.Text);
        movieSystem.WriteMovieListToFile();
        ListViewItem movieItem = new ListViewItem(txtTitle.Text);
        movieItem.SubItems.Add(txtGenre.Text);
        movieItem.SubItems.Add(txtActor.Text);
        movieItem.SubItems.Add(txtYear.Text);
        movieItem.Tag = movie 
        lstMovies.Items.Add(movieItem);
    }
