    public bool isRunning()
    {
        if (move != Moving.None && staminaRegan && keyState.IsKeyDown(Keys.Space))
        {
            EntityAnimation.interval = 10;
            return true;
        }
        else
        {
            EntityAnimation.interval = 65;
            return false;
        }
    }
