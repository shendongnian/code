    private void InitializeDctionary(int typeId, IList < Game > gameInformations, IList < UserInfo > userInformations) 
    {
        if (!_scoreDictionary.ContainsKey(typeId)) 
        {
            lock(_scoreDictionaryLock) 
            {
    
                if (!_scoreDictionary.ContainsKey(typeId)) 
                {
                    _scoreDictionary.Add(typeId, new Dictionary < int, Dictionary < string, int >> ));
                }
    
                foreach(var gameInformation in gameInformations) 
                {
                    var orderdUsers = userInformations.Where(s => s.GameId == gameInformation.Id)
                        .OrderByDescending(s => s.Score)
                        .Select((value, index) =>
                            new { value, index //this is the user rank
                            })
                        .Select(p =>new {p.value.UserName,p.index})
                        .Select(p => new KeyValuePair < string, int > (p.UserName, p.index));
        
                    if (!_scoreDictionary[typeId].ContainsKey(gameInformation.Id))
                        _scoreDictionary[typeId].Add(gameInformation.Id, new Dictionary < string, int > ());
        
                    _scoreDictionary[typeId][gameInformation.Id] = orderdUsers.ToDictionary(x => x.Key, x => x.Value);
                }
            }
        }
    }
