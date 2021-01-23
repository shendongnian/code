    Game1 game = new Game1();
    Task.Factory.StartNew(() => 
    {
        game.Run();
    }
