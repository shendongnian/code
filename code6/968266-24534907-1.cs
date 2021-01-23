    Point p = Snake.Body.Where(x => x.X == Food.Point.X && p.Y == Food.Point.Y).SingleOrDefault();
    if(p.X != 0 && p.Y != 0)
    {
         Points++;
         Food = new FoodSpawn();
         Snake.Grow(Points + 4); 
    }
