      float timer = 1f;
      while (i <= 1 ) 
                {
                    EnemyVelocity.X += 1f;
                    timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                    usedTimeRight = timer;
                    i++;
                } 
    
    
                if (usedTimeRight != 0) 
                {
                    do
                    { EnemyVelocity.X -= 1f;
                      timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                    } while ((timer - usedTimeRight) >= 5);
                    usedTimeLeft = timer;
                    usedTimeRight = 0;
                }
                if (usedTimeLeft != 0)
                {
                    do
                    { EnemyVelocity.X += 1f;
                      timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                    }
                    while (timer - usedTimeLeft >= 5);
                    usedTimeRight = timer;
                    usedTimeLeft= 0;
                }
