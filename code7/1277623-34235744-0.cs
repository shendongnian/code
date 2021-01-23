    private static bool levelup = true;
    private static void Obj_AI_Base_OnLevelUp(Obj_AI_Base sender, EventArgs args)
    {
        Game.PrintChat("you leveled up!");
    }
    public bool results()
    {
        return levelup;            
    }
