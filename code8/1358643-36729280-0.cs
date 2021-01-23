    var ids = context.Empoyees.Where(e => e.FacilityId == 4)
                     .Select(e => e.Id).ToArray();
    
    foreach(int id in ids)
    {
        var emp = new Empoyee { Id = id }; // Stub entity
        context.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
    }
    
    context.SaveChanges();
