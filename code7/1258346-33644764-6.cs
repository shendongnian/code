        foreach (Label i in board)
        {
            if (x >= 1024)
            {
                x = 0;
                y += i.Height + 55;
            }
            else if (y >= 1024)
            {
                y = 0;
                x += i.Width + 55;
            }
        }
