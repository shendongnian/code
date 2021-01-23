    using System;
    using System.Net;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;
    
    namespace TagSearch.Plugins
    {
        public class Spotify : IClass
        {
            #region JsonParseData
    
            public class Rootobject
            {
                public Tracks tracks { get; set; }
            }
    
            public class Tracks
            {
                public List<Item> items { get; set; }
            }
    
            public class Item
            {
                public Album album { get; set; }
                public List<Artist> artists { get; set; }
                public int disc_number { get; set; }
                public string name { get; set; }
                public int track_number { get; set; }
            }
    
            public class Album
            {
                public string href { get; set; }
                public string release_date { get; set; }
                public string release_date_precision { get; set; }
                public List<Image> images { get; set; }
                public string name { get; set; }
            }
    
            public class Image
            {
                public int height { get; set; }
                public string url { get; set; }
                public int width { get; set; }
            }
    
            public class Artist
            {
                public string name { get; set; }
            }
    
            #endregion
            protected Dictionary<String, int> _TempTotal;
            protected Dictionary<String, List<ITag>> _TempTag;
            private object _Lock = new object();
            public Spotify()
            {
                JParse = new System.Text.Json.JsonParser();
                _TempTotal = new Dictionary<string, int>();
                _TempTag = new Dictionary<String, List<ITag>>();
            }
            public override void Search(string Name)
            {
                GetInfo(Name);
            }
            protected override void GetInfo(string Name)
            {
                lock (_Lock)
                {
                    _TempTotal.Add(Name, -1);
                    _TempTag.Add(Name, new List<ITag>());
                }
                
                var web = new IWebClient();
                web.DownloadDataCompleted += DownloadDataCompleted;
                web.DownloadDataAsync(new Uri("https://api.spotify.com/v1/search?&type=track&limit=50&q=" + Uri.EscapeDataString(Name.ToLower())), new IWebClient.WebClientState(Name, 1, null));
    
                while (_TempTotal[Name] != _TempTag[Name].Count) { System.Threading.Thread.Sleep(1000); }
    
                OnEvent(Name,_TempTag[Name]);
    
                _TempTotal.Remove(Name);
                _TempTag.Remove(Name);
                base.GetInfo(Name);
            }
            protected void DownloadDataCompleted(dynamic sender, dynamic e)
            {
                if (e.Result != null)
                {
                    string Name = e.UserState.Name;
                    switch ((int)e.UserState.State)
                    {
                        case 1:
                            var _RootObject = JParse.Parse<Rootobject>(Encoding.UTF8.GetString(e.Result));
                            _TempTotal[Name] = _RootObject.tracks.items.Count;
                            foreach (var Json in _RootObject.tracks.items)
                            {
                                var web = new IWebClient();
                                web.DownloadDataCompleted += DownloadDataCompleted;
                                web.DownloadDataAsync(new Uri(Json.album.href), new IWebClient.WebClientState(Name, 2, new ITag(this.GetType(), Json.name, Json.album.name, Json.artists[0].name, null, DateTime.MinValue, Json.disc_number, Json.track_number)));
                                System.Threading.Thread.Sleep(250);
                            }
                            sender.Dispose();
                            break;
    
                        case 2:
                            var Json2 = JParse.Parse<Album>(System.Text.Encoding.UTF8.GetString(e.Result));
                            e.UserState.State = 3;
                            switch ((string)Json2.release_date_precision)
                            {
                                case "year": e.UserState.Tag.RelaseDate = DateTime.Parse(Json2.release_date + "-01-01"); break;
                                case "month": e.UserState.Tag.RelaseDate = DateTime.Parse(Json2.release_date + "-01"); break;
                                case "day": e.UserState.Tag.RelaseDate = DateTime.Parse(Json2.release_date); break;
                            }
                            sender.DownloadDataAsync(new Uri(Json2.images[0].url), e.UserState);
                            break;
    
                        case 3:
                            e.UserState.Tag.Cover = e.Result;
                            _TempTag[Name].Add(e.UserState.Tag);
                            sender.Dispose();
                            break;
                    }
                }
            }
        }
    }
