    if (Keyboard.GetState().IsKeyDown(Keys.Space) && hasJumped == false && !spacebarDown)
    {
        sound.Play(volume, pitch, pan); // plays jumping sound
        position.Y -= 5f;               // position of jump
        velocity.Y = -10.5f;            // velocity of jump 
        hasJumped = true;
        spacebarDown = true;
    }
    if(Keyboard.GetState().IsKeyUp(Keys.Space))
    {
        spacebarDown = false;
    }
