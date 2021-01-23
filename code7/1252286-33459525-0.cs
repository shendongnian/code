    public void Update(PersonCallViewModel personCall)
        {
            var entity = new PersonCall();
            var entity2 = new Destination();
            entity.DestinationId = personCall.DestinationId;
            entity.Destination.DestinationId = personCall.DestinationId;
            entity.FirstName = personCall.FirstName;
            entity.LastName = personCall.LastName;
            entity.Job = personCall.Job;
            entities.PersonCall.Attach(entity);
            var equalDestination = entities.Destination.Where(pd => pd.DestinationId == entity.DestinationId);
            foreach (var item in equalDestination)
            {
                item.Number = personCall.Pager;
            }
            entity2 = equalDestination.FirstOrDefault();
            entities.Destination.Attach(entity2);
            entities.Entry(entity).State = EntityState.Modified;
            entities.Entry(entity2).State = EntityState.Modified;
            entities.SaveChanges();
        }
