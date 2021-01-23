     public void Add(string outerKey, string innerKey, string innerValue)
        {
            //out to out dictionary
            if (!myDictionary.ContainsKey("outerKey"))
            {
                myDictionary.Add("outerKey", new Dictionary<string, List<string>>());
            }
            //out to inner dictionary
          if(!myDictionary[outerKey].ContainsKey(innerKey))
          {
              myDictionary[outerKey].Add(innerKey,new List<string>());
          }
            // add to list of inner dictionary
          myDictionary[outerKey][innerKey].Add(innerValue);
        }
 
