                        do
                        {
                            for (int i = 0; i < list.Count(); i++)
                            {
                                if (blacknumber >= list.Count())
                                    i = blacknumber % list.Count();
                                else
                                    i = blacknumber;
                                list.RemoveAt(i);
                            }
                        } while (list.Count > 1);
