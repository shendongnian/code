    public void MoveRightPaddle()
    {
        if (ball.Position.Y >= paddleComputer.Position.Y)
        {
            paddleComputer.Position.Y += BALLSPEED; // I don't know why this uses a different value from the else statement
        }
        else 
        {
            paddleComputer.Position.Y -= ball.Velocity.Y;
        }
    }
