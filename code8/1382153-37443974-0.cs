    static void Main(string[] args)
    {
        Context db = new Context();
        Company company = new Company{};
        Genre genre = new Genre
        {
            GenreTypeID = 1
        };
        Console console = new Console
        {
            Title = "NES",
            ReleaseDate = new DateTime(2015, 1, 1),
        };
        db.Consoles.Add(console);
        Game game = new Game
        {
            Company = company,
            Console = console,
            Genre = genre,
            Title = "Final Fantasy I",
            Description = "Blabla",
            ReleaseDate = new DateTime(1986, 1, 1)
        };
        db.Games.Add(game);
        Game game2 = new Game
        {
            Company = company,
            Console = console,
            Genre = genre,
            Title = "Final Fantasy VII",
            Description = "Blabla",
            ReleaseDate = new DateTime(1986, 2, 2)
        };
        db.Games.Add(game2);
        db.SaveChanges();
    }
    public class Game
    {
        [Key]
        public int GameID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Genre Genre { get; set; }
        public Console Console { get; set; }
        public Company Company { get; set; }
    }
    
    public class Console
    {
        [Key]
        public int ConsoleID { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
    
    }
    
    public class Company
    {
        [Key]
        public int CompanyID { get; set; }
        public string Name { get; set; }
        public List<Game> Games { get; set; }
        public List<Console> Consoles { get; set; }
    }
    
    public class Genre
    {
        [Key]
        public int GenreID { get; set; }
        public int GenreTypeID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } 
        public List<Game> Games { get; set; }
        public List<Movie> Movies { get; set; }
        public List<Serie> Series { get; set; }
    }
