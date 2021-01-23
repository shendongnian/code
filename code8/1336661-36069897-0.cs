    public ObservableCollection<News> NewsCollection
    {
        get { return (ObservableCollection<News>)GetValue(NewsCollectionProperty); }
        set { SetValue(NewsCollectionProperty, value); }
    }
    public static readonly DependencyProperty NewsCollectionProperty =
        DependencyProperty.Register("NewsCollection", typeof(ObservableCollection<News>), typeof(NewsPage), new PropertyMetadata(null));
    private async void NewsRequest()
    {
        //Fetch News from web
        string response =  await NewsProxy.GetNews("TokenX");
        //Parse News to add to NewsCollection
        ObservableCollection<News> newsCollection;
        bool success = NewsProxy.NewsProxyParser(response, out newsCollection);
        NewsCollection = newsCollection;
        // success is true and NewsCollection has new updated values
        if (success)
        {
            News n = new News();
            n.title = "Just to trigger collectionchanged";
            n.newsText = "dadada";
            n.order = 1;
            NewsCollection.Add(n);
            Debug.WriteLine("Still No GUI updated!!!");
        }
    }
