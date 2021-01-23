    static void Combat(Type enemyType)
    {
        Character.Player player = new Character.Player();
        Character.Enemy enemy = Activator.CreateInstance(enemyType) as Character.Enemy;
    }
