    public class Lobby
    {
        private Lobby()
        {
            playersByUsername = new Dictionary<string, Player>();
            playersByConnectionID = new Dictionary<string, Player>();
        }
        private static Lobby singleton;
        public static Lobby Get()
        {
            if (singleton == null)
                singleton = new Lobby();
            return singleton;
        }
        Dictionary<string, Player> playersByUsername;
        Dictionary<string, Player> playersByConnectionID;
        public Player GetPlayerByUsername(string username)
        {
            if (playersByUsername.ContainsKey(username))
                return playersByUsername[username];
            return null;
        }
        public Player GetPlayerByConnectionID(string connectionID)
        {
            if (playersByConnectionID.ContainsKey(connectionID))
                return playersByConnectionID[connectionID];
            return null;
        }
        public void NewPlayer(Player player)
        {
            playersByUsername.Add(player.username, player);
            foreach (string connectionID in player.ConnectionIDs)
                playersByConnectionID.Add(connectionID, player);
        }
        public void NewConnection(string username, string connectionID)
        {
            playersByConnectionID.Add(connectionID, playersByUsername[username]);
            playersByUsername[username].ConnectionIDs.Add(connectionID);
        }
    }
