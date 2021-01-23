    if (rect1.IntersectsWith(rect2))
    {
        // assumes that positive Y signifies downward direction
        if (rect1.Top <= rect2.Bottom)
        {
            ...
        }
        else if (rect1.Bottom >= rect2.Top)
        {
            ...
        }
        else if (rect1.Left <= rect2.Right)
        {
            ...
        }
        else if (rect1.Right >= rect2.Left)
        {
            ...
        }
    }
