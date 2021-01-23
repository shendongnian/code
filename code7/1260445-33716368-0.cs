     string line = reader.ReadLine();
                        if (null != line)
                        {
                            list = new List<string>();
    
                            string[] digits = line.Split(new char[] { ' ', '\n', '|' }, StringSplitOptions.RemoveEmptyEntries);
                            for (int i = 0; i < digits.Count() - 1; i++)
                            {
                                list.Add(digits[i]);
                            }
                            int blacknumber = Convert.ToInt32(digits[digits.Count() - 1]);
                            int saveBlackNum = blacknumber;
                            do
                            {
                                for (int i = 0; i < list.Count(); i++)
                                {
                                    if ((list.Count < (blacknumber)))
                                    {
                                        if(blacknumber % list.Count==0 )
                                        {
                                            blacknumber = list.Count();
                                        }
                                        else
                                        {
                                            blacknumber = ((blacknumber) % list.Count());
                                        }                                  
                                        break;
                                    }
                                    if ((list.Count >= (blacknumber)))
                                    {
                                        if (i == blacknumber - 1)
                                        {
                                            list.RemoveAt(blacknumber - 1);
                                            blacknumber = saveBlackNum;
                                            break;
                                        }
                                    }
                                }
                            } while (list.Count > 1);
    
                        }
                        foreach (string str in list)
                        {
                            Console.WriteLine(str);
                        }
                        Console.WriteLine("");
