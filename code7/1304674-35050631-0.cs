    class MovieList
    {
        public List<Movie> TheMovies {get; set;}
    }
    public class Movie
    {
        public string Name { get; set; }
        public int Year { get; set; }
    }
    using (StreamReader file = File.OpenText(@"c:\Temp\movies.json"))
    {
        JsonSerializer serializer = new JsonSerializer();
        MovieList movies = (MovieList)serializer.Deserialize(file, typeof(MovieList));
        foreach(var movie in movies.TheMovies)
        {
            Console.WriteLine(movie.Name);
            Console.WriteLine(movie.Year);
        }
    }
