      ...
      if (!(move == Moving.None) && staminaRegan == true)
        {
            if (keyState.IsKeyDown(Keys.Space))
            {
                EntityAnimation.interval = 10; // <- Aaa! The interval is changed 
                return true;
            }
      ...
