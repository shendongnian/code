    foreach (Bar rod in bar)
    {               
            if(rod.CollisionRectangle.Intersects(GameBall.CollisionRectangle))
            {
                GameBall.speed *= -1;
                
                // Reset position of the ball
                // Something like :
                // For the top bar
                Gameball.y = rod.y + rod.height;
                
                // For the bottom bar
                // Gameball.y = rod.y - Gameball.height
                Console.WriteLine("game" + GameBall.speed);                  
            }
        } 
