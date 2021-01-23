    public enum Behavior
    {  
       Happy,
       Angry,
       Scary
    }
    
    public Behavior GetShopKeeperBehavior()
    {
        DateTime now = DateTime.Now;
    
        if (now.Hour >= 5 && now.Hour < 12) return Behavior.Happy;
        if (now.Hour >=12 && now.Hour < 20) return Behavior.Angry;
        return Behavior.Scary;
    }
    // usage
    Behavior shopKeeperMood = GetShopKeeperBehavior();
    if (shopKeeperMood == Behavior.Happy)
    {
         // shop keeper says "Long time no see!"
    }
