     for (int j = 0; j < enemies.Count; j++)
                {
                    Enemies e = enemies[j];
    
                    //Update Sprite
                    e.Update(Game.GraphicsDevice, gameTime);
    
                    for (int u = 0; u < e.bullets.count; u++) {
                       Bullet b = e.bullets[u];
                       //Check for Collision
                       if (b.collisionRect.Intersects(player.collisionRect))
                       {
                           lives -= 1;
                       }
                    }
                }
