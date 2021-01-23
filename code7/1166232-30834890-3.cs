    public static void Main (string[] args)
    {
        Character player = new Character();
        Map map = new Map(player);
        ReciveInput();
    }
    public class Map
    {
        private readonly Character _player;
        public Map(Character player)
        {
            _player = player;
        }
        public SomeMethod
        {
            // access the character using _player here
        }
    }
