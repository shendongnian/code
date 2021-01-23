                List<List<string>> lstStrings = new List<List<string>>{
                   new List<string>() {"A1","A2","A3"},
                   new List<string> {"B1","B2","B3"},
                   new List<string> {"C1","C2","C3"}
                    };
                    List<List<string>> newList = new List<List<string>>();
                    int j=0;
                     foreach(String s in lstStrings[0])
                     {
                         
                         List<string> innerList = new List<string>();
                         for(int i=0;i<lstStrings.Count;i++)
                        {
                            innerList.Add(lstStrings[i][j]);    
                        }
                        j++;
                        newList.Add(innerList);
                }
                foreach(List<string> lstInner in newList)
                {
                    foreach(string s in lstInner)
                    {
                        Console.Write(s);    
                    }
                    Console.WriteLine();
                }
