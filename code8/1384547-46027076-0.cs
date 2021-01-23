        using (var context = new CrmServiceContext(service))
        {
            var bookableResource = context.BookableResourceSet.Where(b => b.Id == bookableResourceId).FirstOrDefault();
    
            if (bookableResource?.CalendarId != null)
            {
    
                Entity entity = service.Retrieve("calendar", bookableResource.CalendarId.Id, new ColumnSet(true));
                EntityCollection entityCollection = (EntityCollection)entity.Attributes["calendarrules"];
    
                int num = 0;
                List<int> list = new List<int>();
                foreach (Entity current in entityCollection.Entities)
                {
                    DateTime dateTime2 = Convert.ToDateTime(current["starttime"]);
                    if (dateTime2 >= startDate && dateTime2 <= endDate)
                    {
                        list.Add(num);
                    }
    
                    num++;
                }
    
                list.Sort();
                list.Reverse();
    
                for (int i = 0; i < list.Count; i++)
                {
                    entityCollection.Entities.Remove(entityCollection.Entities[list[i]]);
                }
    
                entity.Attributes["calendarrules"] = entityCollection;
                service.Update(entity);
            }
        }
    } 
