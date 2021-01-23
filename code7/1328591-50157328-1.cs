    public static void Main() 
    {
         RocketShip test = new RocketShip ();
        ... // Do some setup stuff here
        //Run the game loop
        while (!EndGameRequested()) 
        {
            test.Move();  <- Object instance error here.
        }
    }
