    for (int i = 0; i < obj.Example.Count(); i++)
                    {
                        foreach (KeyValuePair<string, string> pair in obj.Example[i].Invoice)
                        {
                            string temp3 = pair.Key;
                            string temp2 = pair.Value;
                        }
                    }
