     for (int l = 0; l < 3; l++)
            {
                char charac = 'A';
                for (int k = 0; k < 3; k++)
                {
                    for (int m = 0; m < 4; m++)
                    {
                        if (l == 0)
                            dt.Columns.Add("Name" + charac + m);
                        if (l == 1)
                            dt.Columns.Add("Class" + charac + m);
                        if (l == 2)
                            dt.Columns.Add("Score" + charac + m);
                    }
                    charac++;
                }
            }
