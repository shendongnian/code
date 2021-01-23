    public abstract Monster
    {
        public string name;
        public string specie;
        public Stats baseStats;
        public string imgDir;
        public static Monster CreateMonster(string monster)
        {
            Type[] types = GetTypeInfo().Assembly.GetTypes();
            Type monsterType = types.FirstOrDefault(t => t.Name.ToLower().Equals(monster.ToLower()));
            if (monsterType == null)
                throw new InvalidOperationException("The given monster does not have a Type associated with it.");
            return Activator.CreateInstance(monsterType) as Monster;
        }
    }
    public class Cat : Monster
    {
    }
