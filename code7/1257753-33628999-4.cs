    public List<Request> SelectAllRequests()
    {
         Context.RequestMaster
                .Include("RequestType")
                .Select(x => new Request()
                {
                    RequestId = x.RequestId,
                    RequestType = x.RequestType,
                }).ToList();
    }
