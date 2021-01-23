     var event = new SS.Entity.Event {Name = "New Name" and other properties};
    
     IEnumerable<SS.Entity.User> broadcasters = e.Broadcasters
            .Select(u => new SS.Entity.User
                 {
                  Id = u.Id,
                  SkypeId = u.SkypeId,
                  Name = u.Name
               });
    
     var viewers = e.Viewers.Select(u =>
              new SS.Entity.User
              {
                 Id = u.Id,
                 SkypeId = u.SkypeId,
                  Name = u.Name
              });
    
     //add broadcasters to event
     event.Broadcasters.AddRange(broadcasters);
    
     //add viewers to event
     event.Viewers.AddRange(viewers);
    
     dataContext.Events.Add(event);
     dataContext.SaveChanges();
