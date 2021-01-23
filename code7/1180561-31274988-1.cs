    public IEnumerable<Dog> GetDogsOfMember(int id)
    {
        var memberWithDogs = dbContext.Members
                                      .Include(i => i.Dogs)
                                      .SingleOrDefault(i => i.ID == id);
        if (memberWithDogs != null)
            return memberWithDogs.Dogs;
    
        return null;
    }
