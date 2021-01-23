    public void UpdateEntities(GameTime gameTime)
    {
        player.Update(gameTime);
        enemy.Update(gameTime);
        if(PlayerDistanceFromEnemy() < 50)
            enemy.Follow(player);
    }
