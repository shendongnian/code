    private async void moveData(int x, int y)
    {
        Variables.xValue = x;
        Variables.yValue = y;
        // Check to see if x co-ord needs moving up or down
        if (Variables.xValue > txtData.Location.X) // UP
        {
            Variables.xDir = 1;
        }
        else if (Variables.xValue < txtData.Location.X) // DOWN
        {
            Variables.xDir = -1;
        }
        else // No change
        {
            Variables.xDir = 0;
        }
        // Check to see if y co-ord needs moving left or right
        if (Variables.yValue > txtData.Location.Y) // RIGHT
        {
            Variables.yDir = 1;
        }
        else if (Variables.yValue < txtData.Location.Y) // LEFT
        {
            Variables.yDir = -1;
        }
        else // No change
        {
            Variables.yDir = 0;
        }
        await Animate();
    }
    private async Task Animate()
    {
        while (Variables.xValue != txtData.Location.X && Variables.yValue !=     txtData.Location.Y)
        {
            if (Variables.yDir == 0) // If we are moving in the x direction
            {
                txtData.SetBounds(txtData.Location.X + Variables.xDir, txtData.Location.Y, txtData.Width, txtData.Height);
            }
            else // We are moving in the y direction
            {
                txtData.SetBounds(txtData.Location.X, txtData.Location.Y + Variables.yDir, txtData.Width, txtData.Height);
            }
            await Task.Delay(intervalBetweenMovements);
        }
    }
