    private void PopulateListView(List<FeedItem> listView)
        {
            var adapter = new FeedItemListAdapter (this, listView);
            this.feedItemLisView.Adapter = adapter;
            this.feedItemLisView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => 
            {
                var myitem = adapter.GetItemAtPosition(e.Position);
                //do something with selected feeditem
            };
