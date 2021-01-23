    private void btnDeleteMovie_Click(object sender, EventArgs e)
    {
        ListViewItem selectedItem = lstMovies.Items[0];
        lstMovies.Items.Remove(selectedItem);
        movieSystem.DeleteMovie((Movie)(selectedItem.Tag));
    }
