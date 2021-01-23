      public async void positionUp()
    {
        if (!keyUpIsDown) //needed to prevent this while loop being accessed multiple times
        {
            keyUpIsDown = true;
            while (keyUpIsDown)
                {
                SelectionNo += 1;
                if (Keyboard.IsKeyUp(Key.Up))
                {
                    keyUpIsDown = false;
                }
                await Task.Delay(100); //you will need to tune this, but it can't be 0
            }
        }
    }
