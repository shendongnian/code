    while (true)
            {
                if (x < 750 && y == 0)
                {
                    x += 5;
                }
                else if (x == 750 && y < 340)
                {
                    y += 5;
                }
                else if (x > 0 && y >= 340)
                {
                    x -= 5;
                }
                else if (x == 0 && y > 0)
                {
                    y -= 5;
                }
                break;
            }
