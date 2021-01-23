                        do
                        {
                            int i =0;
                                if (blacknumber >= list.Count())
                                    i = blacknumber % list.Count();
                                else
                                    i = blacknumber;
                                list.RemoveAt(i);
                            
                        } while (list.Count > 1);
