    public IEnumerable<Request> GetAllUnResolvedRequests() 
    {
        return GetNewContext().Requests.Where(o => !o.IsResolved).ToList();
    }
   
