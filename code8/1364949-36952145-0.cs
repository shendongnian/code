     public class FavoriteSong
    {
        public string _id { get; set; }
        public string title { get; set; }
        public string album { get; set; }
        public string primaryArtist { get; set; }
        public string artist { get; set; }
        public string primaryGenre { get; set; }
        public string genre { get; set; }
        public string duration { get; set; }
        public int year { get; set; }
    }
    public class AddFavorites
    {
        public ObservableCollection<FavoriteSong> favoriteSongs { get; set; }
    }
    public class MainClass
    {
        public string _id { get; set; }
        public AddFavorites addFavorites { get; set; }
    }
