    string[] allLines = {
                                        "200007 XXXX Check XXXX yyy 50", 
                                        "200013 YYYY Check ZZZZ yyy 50", 
                                        "200015 ",
                                        "2541111"
                                    };
    
                for (int i = 0; i < allLines.Length; i++)
                {
                    string param1 = null;
                    string param2 = null;
                    int spaceIndex = allLines[i].IndexOf(' ');
    
                    if (spaceIndex > 0)
                    {
                        param1 = allLines[i].Substring(0, spaceIndex);
    
                        if (spaceIndex < allLines[i].Length - 1)
                        {
                            param2 = allLines[i].Substring(spaceIndex + 1, allLines[i].Length-1 - spaceIndex);
                        }                    
                    }
                    else
                    {
                        param1 = allLines[i];
                    }
    
                    Console.WriteLine("param1:{0} param2:{1}", param1, param2);
                }
