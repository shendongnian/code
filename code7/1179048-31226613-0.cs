    public abstract Monster
    {
        public string name;
        public string specie;
        public Stats baseStats;
        public string imgDir;
        public static T CreateMonster<T>() where T : Monster, new()
        {
            return new T();
        }
    }
    public class Cat : Monster
    {
    }
