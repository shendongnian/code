    switch (result)
            {
                case "Left":
                    TheEater.MoveLeft(ClientRectangle);
                    Invalidate(TheEater.GetFrame());
                    CheckIfEaterIsCloseToMe(); // new method
                    break;
                case "Right":
                    TheEater.MoveRight(ClientRectangle);
                    Invalidate(TheEater.GetFrame());
                    break;
...
    private void CheckIfEaterIsCloseToMe()
    {
        for (int i = 0; i < Stones.Count; i++)
        {
            Rectangle stoneRect = ((Stone)Stones[i]).GetFrame();
            if (TheOtherEater.GetFrame().IsClose(stoneRect, TheOtherEater.GetFrame()))
            {
                // call move method maybe - or just move
            }
        }
       
    }
    private bool IsClose(Rectange r1, Rectangle r2)
    {
        // check if the r1 is close to r2 -- get the left - right - top - bottom of each rectangle
        // first you need to determine if the other rectangle is on the left or right or top or bottom of this rectangle
        if( ( (r1.X + r1.Width)  - r2.X) <= 20 ) // 20 is threshold -- if on the right -- take the right side minus left side
        {
               // move stone how you want -> maybe to the right more
               return true;
        }
        return false;
    }
