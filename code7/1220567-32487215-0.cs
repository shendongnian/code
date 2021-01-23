    public class Friend
    {
        public string steamid { get; set; }
        public string relationship { get; set; }
        public int friend_since { get; set; }
    }
    public class Friendslist
    {
        public List<Friend> friends { get; set; }
    }
    public class RootObject
    {
        public Friendslist friendslist { get; set; }
    }
