    public static class GameItemService
    {
        // We don't have a database, just a singleton
        public static List<GameItem> LIST_OF_GAME_ITEMS; // A singleton for add/retrieve data
        static GameItemService()
        {
            LIST_OF_GAME_ITEMS= new List<GameItem>();
            // Add to the list here
        }
