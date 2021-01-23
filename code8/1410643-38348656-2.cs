    public class PlayerFactory
    {
        public Player Create<V>()
            where V : Vocation
        {
            Player p;
            p = new Player();
            p.SetVocation<V>();
            return p;
        }
    }
