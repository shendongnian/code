                for (int x = 0; x < ms.Count; x++)
            {
                if (xl[x] != "")
                {
                    continue;
                }
                else if (xl[x] == "")
                {
                    for (int y = 0; y<xl.Count; y++)
                    {
                        if (ms[y] == ms[x])
                        {
                            xl[x] = xl[y];
                            break;
                        }
                    }
                    continue;
                }
            }
