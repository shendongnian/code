    static void callCubes()
    {
        cube blank = new cube();
        blank.base_stats(00, "Blank", 0, 0, 0, 0, 0, 0.00); //id, name, atk, def, speed, sp. atk, sp. def, health
        blank.ev_stats(0, 0, 0, 0, 0, 0.00); //atk, def, speed, sp. atk, sp. def, health
        blank.moveSet(00, 00, 00, 00);//move1, move2, move3, move4
        //Test Output
        Console.WriteLine("Name: " + blank.name);
        Console.WriteLine("Health: " + blank.health);
        Console.WriteLine("Attack: " + blank.attack);
        Console.WriteLine("");
        Console.ReadKey();
    }
