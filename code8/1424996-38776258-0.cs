    List<string> resultado = new List<string>();
    result = userList.Where(x => x.Id == IdList[0]).
              Select(x => x.Name).ToList();
    
    for(int i =1; i<IdList.Count();i++)
    {
        result = userList.Where(x => x.Id == IdList[i]).
              Select(x => x.Name).ToList().
              Intersect(result).ToList();
    }
