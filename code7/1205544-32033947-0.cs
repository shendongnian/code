     public class FeedItemViewModel : System.ComponentModel.INotifyPropertyChanged
    {
        // Declaration - Title, Image, Lead, Url
      private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }
        // All from RSS (Image and lead)
        private string _lead;
        public string Lead
        {
            get
            {
                return _lead;
            }
            set
            {
                _lead = value;
                
                // Load picture
                try
                {
                    if (TryParseImageUrl(_lead, out _imageUrl))
                        _imageUrl = _imageUrl.Replace("//", "http://");
                }
                catch { }
                OnPropertyChanged("Lead");
            }
        }
        private string _imageUrl;
        public Uri Image
        {
            get
            {
                if (HasImage)
                    return new Uri(_imageUrl, UriKind.RelativeOrAbsolute);
                return null;
            }
        }
        // Check if picture exists
        public bool HasImage
        {
            get
            {
                return (!string.IsNullOrEmpty(_imageUrl) && Uri.IsWellFormedUriString(_imageUrl, UriKind.RelativeOrAbsolute));
            }
        }
        // Download url news
        private string _url;
        public string Url
        {
            get
            {
                return _url;
            }
            set
            {
                _url = value;
                OnPropertyChanged("Url");
            }
        }
        public void OnOpenUrl()
        {
            var wb = new Microsoft.Phone.Tasks.WebBrowserTask();
            wb.Uri = new Uri(_url);
            wb.Show();
        }
        // 3 method parse image
        private static bool TryParseImageUrl(string description, out string result)
        {
            string str = ParseAnyImageInTheDescription(description);
            result = str;
            return (!string.IsNullOrEmpty(str) && Uri.IsWellFormedUriString(str, UriKind.RelativeOrAbsolute));
        }
        private static string ParseAnyImageInTheDescription(string item)
        {
            if (item == null) { return null; }
            return ParseImageUrlFromHtml(item);
        }
        private static string ParseImageUrlFromHtml(string html)
        {
            Match match = new Regex("src=(?:\\\"|\\')?(?<imgSrc>[^>]*[^/].(?:jpg|png|jpeg))(?:\\\"|\\')?").Match(html);
            if ((match.Success && (match.Groups.Count > 1)) && (match.Groups[1].Captures.Count > 0))
            {
                return match.Groups[1].Captures[0].Value;
            }
            return null;
        }
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
