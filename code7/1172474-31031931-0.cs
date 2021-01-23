    static ShotgunOption GetOptionFromUser()
    {
        char menuItem = null;
        DisplayMenu();
        var menuItem = char.ToUpper(char.Parse(Console.ReadLine()));
        while (menuItem != 'S' && menuItem != 'P' && menuItem != 'R')
        {
            Console.WriteLine("Error - Invalid menu item");
            DisplayMenu();
            menuItem = char.ToUpper(char.Parse(Console.ReadLine()));
        }
        if (menuItem == 'S')
        {
            return ShotgunOption.Shoot;
        }
        else if (menuItem == 'P')
        {
            return ShotgunOption.Shield;
        }
        return ShotgunOption.Reload;
    }
