    string[] name = "a,b,c,d".Split(',');//key
    string[] path = "w,x,y,z".Split(',');//value
    List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
    
                    for (int i = 0; i < name.Length; i++)
                    {
                        for (int j = 0; j < path.Length; j++)
                        {
                            if (i == j)
                            {
                                list.Add(new KeyValuePair<string, string>(name[i], path[j]));
                            }
                        }
                    }
