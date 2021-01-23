    public class XmlRepository<TEntity> : IRepository<TEntity> where TEntity : IEntity
    {
        private readonly string _filePath;
        private readonly Lazy<List<TEntity>> _items;
        public XmlRepository(string filePath)
        {
            _filePath = filePath;
            _items = new Lazy<List<TEntity>>(Load);
        }
        public IEnumerable<TEntity> Items
        {
            get { return _items.Value; }
        }
        public void Add(TEntity item)
        {
            if (_items.Value.Contains(item))
                throw new InvalidOperationException();
            _items.Value.Add(item);
        }
        public void Delete(TEntity item)
        {
            _items.Value.Remove(item);
        }
        public void Save()
        {
            var serializer = new XmlSerializer(typeof(List<TEntity>));
            using (var reader = File.CreateText(_filePath))
            {
                serializer.Serialize(reader, _items.Value);
            }
        }
        private List<TEntity> Load()
        {
            if (!File.Exists(_filePath))
                return new List<TEntity>();
            var serializer = new XmlSerializer(typeof(List<TEntity>));
            using (var reader = File.OpenText(_filePath))
            {
                return (List<TEntity>)serializer.Deserialize(reader);
            }
        }
    }
    public static class RepositorySingletons
    {
        private static IRepository<Game> _gameRepository; 
        
        public static IRepository<Game> GameRepository
        {
            get
            {
                return _gameRepository ??
                    (_gameRepository = new XmlRepository<Game>("Game.xml"));
            }
        }
    }
    public class MyGamesApplication
    {
        private readonly IRepository<Game> _gameRepository;
        public MyGamesApplication(IRepository<Game> gameRepository)
        {
            // I don't care if I have a singleton or not :)
            _gameRepository = gameRepository;
        }
        public MyGamesApplication()
        {
            // I need to fetch a singleton :(
            _gameRepository = RepositorySingletons.GameRepository;
        }
        public void Run()
        {
            var game = new Game
            {
                Id = 55378008,
                Title = "Abe's Oddysee"
            };
            _gameRepository.Add(game);
            Console.WriteLine("Added game " + game.Title);
            _gameRepository.Save();
            Console.WriteLine("Saved games");
        }
    }
