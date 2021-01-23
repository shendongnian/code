     var query= from e in Context.Entities.Include(c=>c.ChildEntities)
                select new EntityDTO
                {
                    EntityName= e.EntityName,
                    ChildEntites= e.ChildEntites.Where(c => c.IsEnabled == true) 
                };
