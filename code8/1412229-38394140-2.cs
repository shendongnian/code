    public bool isRunning()
    {
        bool isMovingQuickly = (move != Moving.None) && staminaIsRegenerating && keyState.IsKeyDown(Keys.Space);
        if (isMovingQuickly)
            EntityAnimation.interval = 10;
        else
            EntityAnimation.interval = 65;
        return isMovingQuickly;
    }
