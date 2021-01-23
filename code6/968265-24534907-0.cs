    for(int x = 0; x < Snake.Body.Length; x++)
    {
        Point p = Snake.Body[x];
        if (p.X == Food.Point.X && p.Y == Food.Point.Y)
        {
              Points++;
              Food = new FoodSpawn();
              Snake.Grow(Points + 4); 
              break;
        }
    }
