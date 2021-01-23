    var item   = adapter [e.Position];
    newsDetail = new Intent(Application.Context, typeof(FeedDetails));
    FeedItem items = new FeedItem() {
        Title   = item.Title,
        Content = item.Content,
    };
    newsDetail.PutExtra(MTitle, items.Title);
    newsDetail.PutExtra(Description, items.Content);
