          private Dictionary<string, long> someDict;
          public List<string> someList;
            
            foreach (string t in someList.Where(t => someDict.ContainsKey(t)))
            {
                  if(someOtherCondition){ }
            }
