    private bool AnneActivated = false;
    if (player.Bounds.Intersects(anneTrigger.Bounds))
    {
       AnneActivated = true;
    }
    if(AnneActivated)
    {
       Anne.UpdateForAnne(gameTime);  
       Anne.LoadHumanContent(Content);
    }
