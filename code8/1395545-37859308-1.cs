    private static Random generator = null; 
    
    /*
     *  Calls onSuccess() chanceOfSuccess% of the time, otherwise calls onFailure() 
     */
    public void SplitAtRandom(int chanceOfSuccess, Action onSuccess, Action onFailure)
    {
        // Seed
        if (generator == null)
            generator = new Random(DateTime.Now.Millisecond);
    
        // By chance
        if (generator.Next(100) < chanceOfSuccess)
        {
            if (onSuccess != null)
                onSuccess();
        }
        else
        {
            if (onFailure != null)
                onFailure();
        }
    }
