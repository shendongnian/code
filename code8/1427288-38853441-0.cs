    private void LsvSearch_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
    {
        ....
        Bundle valuesForActivity = new Bundle();
        valuesForActivity.PutInt("placeId", searchResults[e.Position].resultId); // lsvSearch.SelectedItemPosition always returns -1
    
        Intent resultIntent = new Intent(this, typeof(AboutPlace));
        ....
    }
