    public class FavoriteGroup
    {
        public string GroupName { get; set; }
        public IEnumerable<KeyValuePair<int, string>> Options { get; set; }
        public int SelectedAnswer { set; get; }
    }
