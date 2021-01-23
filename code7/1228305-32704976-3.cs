    Dictionary<string, string> converter = new Dictionary<string, string>();
    converter.Add("shrug", @"¯\_(ツ)_/¯");
    converter.Add("omg", @"◕_◕");
    private static void Game_OnInput(GameInputEventArgs args)
    {
        newtext = args.Input;
        foreach(KeyValuePair<string, string> kvp in converter)
            if (args.Input.Contains(kvp.Key))
            {
               newtext = args.Input.Replace(kvp.Key, kvp.Value);
               Game.Say(newtext);
            }
    }
