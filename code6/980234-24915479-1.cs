    class Game
    {
        Point thePoint;
        Paintball gun;
        public Game()
        {
            thePoint = new Point(50, 50);
            gun = new Paintball(thePoint);
        }
    }
