    public override Group Update(Group entity)
    {
        if (entity.Users != null)
        {
            foreach(var user in entity.Users){
              user.GroupId = x.Id == 0 ? 0 : entity.Id;
              user.UserId = x.User.Id;
             dbContext.Entry(child).State = EntityState.Modified;
            }
           
        }
    
        return dbContext.UpdateGraph<Group>
            (entity,
                map => map.OwnedCollection(x => x.Users, with => with.AssociatedEntity(c => c.Users))
            );
    }
