    foreach (Bar rod in bar)
    {
        if(rod.CollisionRectangle.Intersects(GameBall.CollisionRectangle))
        {
            GameBall.speed *= -1;
            Console.WriteLine("game" + GameBall.speed);
            break;
        }
    }
