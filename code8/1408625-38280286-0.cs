    private async void ExecuteSearchButton_Click(object sender, System.EventArgs e)
    {
        spinner.Visibility = ViewStates.Visible;
        CollectionFeed feed = await CollectionFeed.SearchAsync(searchEditText.Text);
        GenericAdapter<Collection, CollectionViewHolder> adapter = 
                new GenericAdapter<Collection, CollectionViewHolder>(Resource.Layout.CollectionRecyclerViewItem,
                                                                     feed.Results, view => new CollectionViewHolder(view));
            
        searchResultRecyclerView.SetAdapter(adapter);
        spinner.Visibility = ViewStates.Gone;
    }
