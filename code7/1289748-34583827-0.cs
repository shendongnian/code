    public class SteamMemberViewModel
    {
        public Response response { get; set; }
    }
    public class Response
    {
        public int game_count { get; set; }
        public Game[] games { get; set; }
    }
    public class Game
    {
        public int appid { get; set; }
        public string name { get; set; }
        public int playtime_forever { get; set; }
        public string img_icon_url { get; set; }
        public string img_logo_url { get; set; }
        public bool has_community_visible_stats { get; set; }
    }
