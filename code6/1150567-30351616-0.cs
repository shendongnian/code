    float BallXVel = 10;
    float BallYVel = 20;
    
    void Timer_Tick(object sender, object e)
    {
        //always move the ball.
        BallTransform.TranslateX += BallXVel;
        BallTransform.TranslateY += BallYVel;
    
        //bounce the ball up if it hits the paddle and is not already moving up
        if (!rectPaddle.IsEmpty && BallYVel > 0)
        {
           BallYVel = 0-BallYVel;
        }
        
        if (BallTransform.TranslateY - 50 > PaddleTransform.TranslateY)
        {
               BallTransform.TranslateY -= 20;
               Result.Text = ("Game Over!");
        }
    
    }
