    partial class MainActivity {
        public static string MTitle = "";
        public static string Description = "";
        void PopulateListView(List<FeedItem> listView)
        {
            ...
            var newsDetail = new Intent(...);
            newsDetail.PutExtra(MTitle,      items.Title);
            newsDetail.PutExtra(Description, items.Description);
        }
    }
