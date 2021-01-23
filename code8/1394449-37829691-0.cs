    public ICollection<OwnerTransport> GetOwnerTransportByTransportId(int transportId, int? skip = null, int? take = null)
    {
        using (var context = new DBContext())
        {
           // base query
           var query = context.OwnerTranports.AsQueryable();
           // execute filter on transport ID
           query = query.Where(t => t.TransportID == transportId.Value);
           // apply skip/take
           if (skip.HasValue)
           {
               query = query.Skip(skip.Value);
           }
           if (take.HasValue)
           {
               query = query.Take(take.Value);
           }         
           // Materialize data. This pulls it from DB store into memory.
           var data = query.ToList();
           return data;
        }
    }
