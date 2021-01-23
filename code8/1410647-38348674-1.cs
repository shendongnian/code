    public class Vocation
    {
        public Vocation()
        {
        }
        public Vocation(int i)
        {
        }
    }
    public class Player : Creature
    {
        Vocation v;
        public Player(int i)
        {
        }
        public void SetVocation(int value)
        {
            // if you wanna set it to value 
            v = new Vocation(value);
        }
    }
