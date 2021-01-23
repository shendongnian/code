     Dictionary<int, string> myDic = new Dictionary<int, string>();
                    myDic.Add(1, "a");
                    myDic.Add(2, "b");
                    myDic.Add(3, "c");
                    myDic.Add(4, "d");
                    myDic.Add(5, "e");
                    myDic.OrderBy(cond => cond.Key); //sort by key
                    myDic.OrderBy(cond => cond.Value); //sort by value
