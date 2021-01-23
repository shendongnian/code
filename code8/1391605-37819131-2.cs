    public class ViewModel : BindableBase
    {
        ObservableCollection<Feed> feeds = new ObservableCollection<Feed>();
        public ViewModel()
        {
        }
        public async Task LoadFeeds()
        {
            var myFeeds = new ObservableCollection<Feed>();
            Feed feed1 = new Feed();
            feed1.Title = "Feed A";
            feed1.Articles = new List<Article>() { new Article() { Title = "Article 1", HeadLine = "Headline 1" },
            new Article() { Title = "Article 2", HeadLine = "Headline 2"},
            new Article() { Title = "Article 3", HeadLine = "Headline 3"}};
            myFeeds.Add(feed1);
            Feed feed2 = new Feed();
            feed2.Title = "Feed B";
            feed2.Articles = new List<Article>() { new Article() { Title = "Article 4", HeadLine = "Headline 4" } };
            myFeeds.Add(feed2);
            Feed feed3 = new Feed();
            feed3.Title = "Feed C";
            feed3.Articles = new List<Article>() { new Article() { Title = "Article 5", HeadLine = "Headline 5" },
            new Article() { Title = "Article 6", HeadLine = "Headline 6"}};
            myFeeds.Add(feed3);
            Feeds = myFeeds;
        }
        public ObservableCollection<Feed> Feeds
        {
            get { return this.feeds; }
            set
            {
                Set<ObservableCollection<Feed>>(ref this.feeds, value);
            }
        }
    }
    public class Feed
    {
        public string Title { get; set; }
        public List<Article> Articles { get; set; }
    }
    public class Article
    {
        public string Title { get; set; }
        public string HeadLine { get; set; }
    }
    public abstract class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual bool Set<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (object.Equals(storage, value))
                return false;
            storage = value;
            this.RaisePropertyChanged(propertyName);
            return true;
        }
        public virtual void RaisePropertyChanged([CallerMemberName]string propertyName = null)
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
                return;
            var handler = PropertyChanged;
            if (!object.Equals(handler, null))
            {
                var args = new PropertyChangedEventArgs(propertyName);
                handler.Invoke(this, args);
            }
        }
    }
