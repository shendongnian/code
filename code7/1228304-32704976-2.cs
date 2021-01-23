    private static void Game_OnInput(GameInputEventArgs args)
    {
        newtext = args.Input;
        for(int x = 0; x < ascii.Count; x++)
            if (args.Input.Contains(ascii[x]))
            {
               newtext = args.Input.Replace(ascii[x], converted[x]);
               Game.Say(newtext);
            }
    }
