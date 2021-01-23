    public async Task<List<User>> QueryDB(User u)
    {
        var collection = _database.GetCollection<User>("UserData");
        var filter = Builders<User>.Filter.Eq(us => us.id, u.id); //best practice to prevent capital or missclick
        List<User> fetchedUsers = new List<User>()
        using (var cursor = await collection.FindAsync(filter))
        {
              while (await cursor.MoveNextAsync())
              {
                     var batch = cursor.Current;
                      foreach (User user in batch)
                            fetchedUsers.Add(user);
              }
        }
        return fetchedUsers;
        
      }
