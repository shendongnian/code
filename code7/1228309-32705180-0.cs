    Dictionary<string, string> dictionary = new Dictionary<string, string>
    {
        {"shrug", @"¯\_(ツ)_/¯" },
        {"omg", "◕_◕" }
    };
    private static void Game_OnInput(GameInputEventArgs args)
    {
        string newtext = args.Input;
        foreach(string key in dictionary.Keys){
            newtext = newtext.Replace(key,dictionary[key]);
        }
        Game.Say(newtext);
}
