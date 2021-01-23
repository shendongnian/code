    public bool isRunning()
    {
        bool result = false;
        if (move != Moving.None && staminaRegan)
        {
            if (keyState.IsKeyDown(Keys.Space))
            {
                EntityAnimation.interval = 10;
                result = true;
            }
            else
            {
                EntityAnimation.interval = 65;
            }
        }
        else
        {
            EntityAnimation.interval = 65;
        }
    
        return result;
    }
