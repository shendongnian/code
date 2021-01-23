        switch(gift1)
        {
            case 1:
                {
                    for (int ik = 0; allbuild[ik] == g[1]; ik++)
                    {
                        if (allbuild[ik] == 0)
                        {
                            allbuild[ik] = g[1];
                            break;
                        }
                    }
                    break;
                }
            case 2:
                {
                    for (int ik = 0; allbuild[ik] == g[2]; ik++)
                    {
                        if (allbuild[ik] == 0)
                        {
                            allbuild[ik] = g[2];
                            break;
                        }
                    }
                    break;
                }
        }
