    private bool AnneActivated = false;
    if (player.Bounds.Intersects(anneTrigger.Bounds))
    {
       AnneActivated = true;
    }
    if(AnneAcivated)
    {
       Anne.UpdateForAnne(gameTime);  
       Anne.LoadHumanContent(Content);
    }
