    void Combat<tEnemy>() where tEnemy : Character.Enemy, new()
    {
        Character.Player player = new Character.Player();
        Character.Enemy gnome = new tEnemy();
    }
