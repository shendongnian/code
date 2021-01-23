    public void SetOwnerOfFirstDog(int ownerId)
    {       
       var dog = context.Dogs.Include(x => x.Owner).First();
       dog.OwnerId = ownerId;
       context.SaveChanges();
    } 
