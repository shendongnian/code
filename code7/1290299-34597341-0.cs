    Random rnd = new Random();
    List<User> resultList = new List<User>();
    
    while (resultList.Count < 10)
    {
        User u = listUsr[rnd.Next(listUsr.Count)];
        if (!resultList.Contains(u))
        {
            resultList.Add(u);
        }
    }
