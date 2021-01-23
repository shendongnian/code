    public class ImageCachingSystem : IImageCachingSystem
    {
        private readonly DispatcherTimer _timer = new DispatcherTimer();
        private readonly object l_cachesByName = new object();
        private readonly Dictionary<String, ImageCache> _cachesByName = new Dictionary<String, ImageCache>();
        public ImageCachingSystem()
        {
            _timer.Interval = TimeSpan.FromSeconds(10);
            _timer.Tick += OnTick;
            _timer.Start();
        }
        public BitmapImage GetImage(String a_path)
        {
            return GetImage(new Uri(a_path));
        }
        public BitmapImage GetImage(Uri a_url)
        {
            lock (l_cachesByName)
            {
                var path = a_url.ToString().ToLower();
                if (_cachesByName.ContainsKey(path))
                {
                    return _cachesByName[path].Image;
                }
                else
                {
                    var image = new BitmapImage(a_url);
                    image.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                    image.Freeze();
                    _cachesByName[path] = new ImageCache
                    {
                        Expiration = DateTime.Now + TimeSpan.FromMinutes(30),
                        Path = path,
                        Image = image,
                    };
                    return image;
                }
            }
        }
        private void OnTick(object sender, EventArgs e)
        {
            lock (l_cachesByName)
            {
                var expired = _cachesByName.Where(i => i.Value.Expiration < DateTime.Now).Select(i => i.Key);
                foreach (var key in expired.ToArray())
                    _cachesByName.Remove(key);
            }
        }
        class ImageCache
        {
            public String Path { get; set; }
            public DateTime Expiration { get; set; }
            public BitmapImage Image { get; set; }
        }
    }    
