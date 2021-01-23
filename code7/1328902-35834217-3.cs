      foreach (var picks in possiblePicks)
                {
                    var listToTest = new List<List<int>>(4);
                    foreach (var i in picks)
                        listToTest.Add(data[i]);
    
                    var ok = Check(listToTest, 2);
                    if (ok)
                        break;
                }
      private bool Check(List<List<int>> listToTest, int limit)
            {
                Dictionary<int, int> ret = new Dictionary<int, int>();
                foreach (var inputElem in listToTest)
                {
                    foreach (var z in inputElem)
                    {
                        var returnCount = ret.ContainsKey(z) ? ret[z] : 0;
                        if (!ret.ContainsKey(z))
                            ret.Add(z, returnCount + 1);
                        else
                            ret[z]++;
                    }
    
                }
                return ret.All(p => p.Value == limit);
            }
