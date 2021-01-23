    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<playlist_movie> lists = new List<playlist_movie>() {
                    new playlist_movie() {
                        playlist_id = 1,
                        movie_id = 5,
                        movie = new movie() { movie_id = 5, movie_name = "Test Movie"},
                        playlist = new playlist() { playlist_name = "test playlist", playlist_id = 1}
                    },
                    new playlist_movie() {
                        playlist_id = 1,
                        movie_id = 5,
                        movie = new movie() { movie_id = 5, movie_name = "Test Movie"},
                        playlist = new playlist() { playlist_name = "test playlist", playlist_id = 1}
                    },
                    new playlist_movie() {
                        playlist_id = 5,
                        movie_id = 5,
                        movie = new movie() { movie_id = 5, movie_name = "Test Movie"},
                        playlist = new playlist() { playlist_name = "testtest", playlist_id = 5}
                    }
                };
     
                string moveie_name = "Test Movie";
                var results = lists.Where(x => x.movie.movie_name == moveie_name)
                    .Select(x => new { moveie_name = x.movie.movie_name, movie_id = x.movie_id, playlist_id = x.playlist_id, playlist_name = x.playlist.playlist_name })
                    .GroupBy(x => x.playlist_id)
                    .Select(x => x.FirstOrDefault()).ToList();
            }
        }
        public partial class movie
        {
            public int movie_id { get; set; }
            public string movie_name { get; set; }
            public virtual ICollection<playlist_movie> playlist_movie { get; set; }
        }
        public partial class playlist
        {
            public int playlist_id { get; set; }
            public string playlist_name { get; set; }
            public virtual ICollection<playlist_movie> playlist_movie { get; set; }
        }
        public partial class playlist_movie
        {
            public int id { get; set; }
            public int playlist_id { get; set; }
            public int movie_id { get; set; }
            public virtual playlist playlist { get; set; }
            public virtual movie movie { get; set; }
        }
    }
