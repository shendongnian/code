    public class data
    {
        public string Title { get; set; }
        public string feedTitleBack { get; set; }
        public string Summary { get; set; }
        public string feedSummaryBack { get; set; }
        public string PublishDate { get; set; }
        public string feedPubDateBack { get; set; }
    
        public data() { }
        public data(string Title, string feedTitleBack, string Summary, string feedSummaryBack, string PublishDate, string feedPubDateBack)
        {
            this.Title = Title;
            this.feedTitleBack = feedTitleBack;
            this.Summary = Summary;
            this.feedSummaryBack = feedSummaryBack;
            this.PublishDate = PublishDate;
            this.feedPubDateBack = feedPubDateBack;
        }
    }
    
        void loadData()
        {
            List<data> obj = new List<data>();
            obj.Add(new data("Title1", "Red", "Summary1", "Green", "Date", "Blue"));
            obj.Add(new data("Title1", "#DD4B39", "Summary1", "#006621", "Date", "#1A0DAB"));
            feedListBox.ItemsSource = obj;
        }
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        loadData();
    }
