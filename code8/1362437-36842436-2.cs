      public class MovieListModel
        {
            public MovieListModel()
            {
                MovieList = new List<MovieModel> {new MovieModel{Id=1,Name = "Apocalypse Now",IncrementValue = 3}, new MovieModel {Id = 2,Name = "Three Lions", IncrementValue = 7} };
            }
    
            public List<MovieModel> MovieList { get; set; }
        }
    
        public class MovieModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
    
            public int IncrementValue { get; set; }
        }
    
        public class IncrementMovieCountModel
        {
            public int IncrementValue { get; set; }
            public int MovieId { get; set; }
        }
