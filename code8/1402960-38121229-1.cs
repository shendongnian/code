    [ValueConversion(typeof(ContentPresenter), typeof(ContentPresenterVisualHelper))]
    public class ContentPresenterToVisualHelperConverter : IValueConverter
    {
        /// <param name="parameter">
        /// 1. Can be null/empty, in which case the first Visual Child of the ContentPresenter is returned by the Helper
        /// 2. Can be a string, in which case the ContentPresenter's child with the given name is returned
        /// </param>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return null;
            ContentPresenter cp = value as ContentPresenter;
            if (cp == null)
                throw new InvalidOperationException(String.Format("value must be of type ContentPresenter, but was {0}", value.GetType().FullName));
            return ContentPresenterVisualHelper.GetInstance(cp, parameter as string);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// Exposes either
    /// A) A ContentPresenter's only immediate visual child, or
    /// B) Any of the ContentPresenter's visual children by Name
    /// in the ContentPresenterVisualHelper's "Visual" property. Implements INotifyPropertyChanged to notify when this visual is replaced.
    /// </summary>
    public class ContentPresenterVisualHelper : BindableBase, IDisposable
    {
        private static object CacheLock = new object();
        private static MemoryCache Cache = new MemoryCache("ContentPresenterVisualHelperCache");
        protected readonly ContentPresenter ContentPresenter;
        protected readonly CompositeDisposable Subscriptions = new CompositeDisposable();
        protected readonly string ChildName;
        private FrameworkElement _Visual;
        public FrameworkElement Visual
        {
            get { return _Visual; }
            private set { this.SetProperty(ref _Visual, value); }
        }
        /// <summary>
        /// Creates a unique Cache key for a Combination of ContentPresenter + ChildName
        /// </summary>
        private static string CreateKey(ContentPresenter ContentPresenter, string ChildName)
        {
            var hash = 17;
            hash = hash * 23 + ContentPresenter.GetHashCode();
            if (ChildName != null)
                hash = hash * 23 + ChildName.GetHashCode();
            var result = hash.ToString();
            return result;
        }
        /// <summary>
        /// Creates an instance of ContentPresenterVisualHelper for the given ContentPresenter and ChildName, if necessary.
        /// Or returns an existing one from cache, if available.
        /// </summary>
        public static ContentPresenterVisualHelper GetInstance(ContentPresenter ContentPresenter, string ChildName)
        {
            string key = CreateKey(ContentPresenter, ChildName);
            var cachedObj = Cache.Get(key) as ContentPresenterVisualHelper;
            if (cachedObj != null)
                return cachedObj;
            lock (CacheLock)
            {
                cachedObj = Cache.Get(key) as ContentPresenterVisualHelper;
                if (cachedObj != null)
                    return cachedObj;
                var obj = new ContentPresenterVisualHelper(ContentPresenter, ChildName);
                var cacheItem = new CacheItem(key, obj);
                var expiration = DateTimeOffset.Now + TimeSpan.FromSeconds(60);
                var policy = new CacheItemPolicy { AbsoluteExpiration = expiration };
                Cache.Set(cacheItem, policy);
     
                return obj;
            }
        }
        private ContentPresenterVisualHelper(ContentPresenter ContentPresenter, string ChildName)
        {
            this.ContentPresenter = ContentPresenter;
            this.ChildName = ChildName;
            this
                .ContentPresenter
                .ObserveDp(x => x.Content)
                .DistinctUntilChanged()
                .Subscribe(x => ContentPresenter_LayoutUpdated())
                .MakeDisposable(this.Subscriptions);  // extension method which just adds the IDisposable to this.Subscriptions
            /*
             * Alternative way? But probably not as good
             * 
            Observable.FromEventPattern(ContentPresenter, "LayoutUpdated")
                .Throttle(TimeSpan.FromMilliseconds(50))
                .Subscribe(x => ContentPresenter_LayoutUpdated())
                .MakeDisposable(this.Subscriptions);*/
        }
        public void Dispose()
        {
            this.Subscriptions.Dispose();
        }
        void ContentPresenter_LayoutUpdated()
        {
            Trace.WriteLine(String.Format("{0:hh.mm.ss:ffff} Content presenter updated: {1}", DateTime.Now, ContentPresenter.Content));
            if(!String.IsNullOrWhiteSpace(this.ChildName))
            {
                // Get Visual Child by name
                var child = this.ContentPresenter.FindChild<FrameworkElement>(this.ChildName);  // extension method, readily available on StackOverflow etc.
                this.Visual = child;
            }
            else
            {
                // Don't get child by name, but rather
                // Get the first - and only - immediate Visual Child of the ContentPresenter
                var N = VisualTreeHelper.GetChildrenCount(this.ContentPresenter);
                if (N == 0)
                {
                    this.Visual = null;
                    return;
                }
                if (N > 1)
                    throw new InvalidOperationException("ContentPresenter had more than 1 Visual Children");
                var child = VisualTreeHelper.GetChild(this.ContentPresenter, 0);
                var _child = (FrameworkElement)child;
            
                this.Visual = _child;
            }
        }
    }
