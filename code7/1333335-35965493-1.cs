    static void Main(string[] args)
    {
        //call all cube base details into existance.
        cube cube1 = callCubes();
        //Test Output
        Console.WriteLine("Name: " + cube1.name);
        Console.WriteLine("Health: " + cube1.health);
        Console.WriteLine("Attack: " + cube1.attack);
        Console.WriteLine("");
        Console.ReadKey();
    }
    static cube callCubes()
    {
        cube blank = new cube();
        blank.base_stats(00, "Blank", 0, 0, 0, 0, 0, 0.00); //id, name, atk, def, speed, sp. atk, sp. def, health
        blank.ev_stats(0, 0, 0, 0, 0, 0.00); //atk, def, speed, sp. atk, sp. def, health
        blank.moveSet(00, 00, 00, 00);//move1, move2, move3, move4
        return blank;
    }
