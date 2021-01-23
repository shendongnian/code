    public RocketShip test = new RocketShip ();
    public void Main() 
        {
        ... // Do some setup stuff here
        //Run the game loop
        while (!EndGameRequested()) 
        {
            test.Move();  <- Object instance error here.
        }
