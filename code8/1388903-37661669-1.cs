    private bool AnneActivated = false;
    if (player.Bounds.Intersects(anneTrigger.Bounds))
    {
       AnneActivated = true;
    }
    if(AnneActivated)   // just fixed the minor variable spelling
    {
       Anne.UpdateForAnne(gameTime);  
       Anne.LoadHumanContent(Content);
    }
