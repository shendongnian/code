    static void Main(string[] args)
    {
        while (enemy1hp > 0)
        {
            string hp = "";
            int damage;
            int level;
            int experience = 0;
            int kills = 0;
            int enemy1hp = 200;
            level = 1 + experience;
            experience = kills * 1;
            damage = 50 * level;
            enemy1hp = 200;
            Console.WriteLine("Welcome!");
            hp = "Enemy 1 currently has " + enemy1hp.ToString() + "hp!";
            Console.WriteLine(hp);
            string userValue = Console.ReadLine();
            if (userValue == "1")
            {
                Console.WriteLine("You have used Haven Strike!");
                enemy1hp = enemy1hp - damage;
                hp = "Enemy 1 currently has " + enemy1hp.ToString() + "hp!";
            }
            Console.WriteLine(hp);
            Console.ReadLine();
            if (enemy1hp <= 0)
            {
                kills = kills + 1;
            }
        }
    }
