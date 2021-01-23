    public AddSomethingToDatabase()
    {
        User user = new User
            {
                Email = "anotheruser@gmail.com",
                Registered = DateTime.UtcNow
            };
 
      _repository.Add(obj);
      _repository.Save();
      int id = obj.Id;
    }
