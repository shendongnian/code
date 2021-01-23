    static int eulers(bool[,] pixel)
    {
        int w2 = 0;
        int wc = 0;
        int x = 1;
        int y = 1;
        int M = pixel.GetLength(0), N = pixel.GetLength(1);
        while (y < N)
        {
            while (x < M)
            {
                if (pixel[x - 1, y - 1])
                {
                    x++;
                }
                else
                {
                    bool labelA = !pixel[x - 1, y];
                    while (true)
                    {
                        if (pixel[x, y - 1])
                        {
                            if (!labelA)
                            {
                                wc++;
                            }
                            x = x + 2;
                        }
                        else if (!pixel[x, y])
                        {
                            x++;
                            if (x < N)
                            {
                                labelA = true;
                                continue;
                            }
                        }
                        else
                        {
                            if (labelA)
                            {
                                w2++;
                            }
                            x++;
                            if (x < N)
                            {
                                labelA = false;
                                continue;
                            }
                        }
                        break;
                    }
                }
            }
            y++;
        }
        return w2 - wc;
    }
