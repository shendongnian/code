        public ActionResult Index(string VideoId, string VideoType, int? PageNo)
        {
		
		 VideoViewModel ob = new VideoViewModel();
		 ob = GetFromList();
		 return View(ob);
		}
		 
		 
		 VideoViewModel GetFromList()
         {
            VideoViewModel ob = new VideoViewModel();
            IDatabase cache = Connection.GetDatabase();
            string serializedVideos = cache.StringGet("");
            if (!String.IsNullOrEmpty(serializedVideos))
            {
                ob.PlayList = JsonConvert.DeserializeObject<List<PlayList>>(serializedVideos);
            }
            else
            {
                GetYoutubeVideosFromApi(ob);
                cache.StringSet("", JsonConvert.SerializeObject(ob.PlayList));
            }
            return ob;
        }
		
		
		public void GetYoutubeVideosFromApi(VideoViewModel ob)
        {
            ob.PlayList = new List<PlayList>();
            WebClient wc = new WebClient { Encoding = Encoding.UTF8 };
            try
            {
                string jsonstring = wc.DownloadString("https://www.googleapis.com/youtube/v3/playlists?part=snippet&key=yourkey&maxResults=50&channelId=yourchaneelid");
                JObject jobj = (JObject)JsonConvert.DeserializeObject(jsonstring);
                foreach (var entry in jobj["items"])
                {
                    PlayList pl = new PlayList();
                    pl.Title = entry["snippet"]["title"].ToString();
                    pl.Description = entry["snippet"]["description"].ToString();
                    pl.Id = entry["id"].ToString();
                    pl.VideoList = new List<VideoList>();
                    string jsonstring2 = wc.DownloadString("https://www.googleapis.com/youtube/v3/playlistItems?part=snippet&playlistId=" + entry["id"].ToString() + "&key=yourkey&maxResults=50");
                    JObject jobj2 = (JObject)JsonConvert.DeserializeObject(jsonstring2);
                    foreach (var vl in jobj2["items"])
                    {
                        VideoList v = new VideoList();
                        v.Title = vl["snippet"]["title"].ToString();
                        v.Description = vl["snippet"]["description"].ToString();
                        v.Id = vl["snippet"]["resourceId"]["videoId"].ToString();
                        v.Url = vl["snippet"]["thumbnails"]["medium"]["url"].ToString();
                        var publishTime = vl["snippet"]["publishedAt"].ToString();
                        var temp = DateTime.Parse(publishTime);
                        v.PublishedDate = GetTimeInMonth(temp);
                        pl.VideoList.Add(v);
                    }
                    ob.PlayList.Add(pl);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
		
		
		public static string GetTimeInMonth(DateTime objDateTime)
        {
            const int SECOND = 1;
            const int MINUTE = 60 * SECOND;
            const int HOUR = 60 * MINUTE;
            const int DAY = 24 * HOUR;
            const int MONTH = 30 * DAY;
            var ts = new TimeSpan(DateTime.UtcNow.Ticks - objDateTime.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);
            if (delta < 1 * MINUTE)
                return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";
            if (delta < 2 * MINUTE)
                return "a minute ago";
            if (delta < 45 * MINUTE)
                return ts.Minutes + " minutes ago";
            if (delta < 90 * MINUTE)
                return "an hour ago";
            if (delta < 24 * HOUR)
                return ts.Hours + " hours ago";
            if (delta < 48 * HOUR)
                return "yesterday";
            if (delta < 30 * DAY)
                return ts.Days + " days ago";
            if (delta < 12 * MONTH)
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "one month ago" : months + " months ago";
            }
            else
            {
                int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                return years <= 1 ? "one year ago" : years + " years ago";
            }
        }
		
		
		 private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            string cacheConnection = ConfigurationManager.AppSettings["CacheConnection"].ToString(); 
            return ConnectionMultiplexer.Connect(cacheConnection);
        });
        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
		
		
