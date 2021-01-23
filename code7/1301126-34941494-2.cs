    public abstract class GameBase
    {
        public string GameStatus { get; set; }
        public string GameDuration { get; set; }
        public ObservableCollection<Person> Persons { get; set; }
    }
