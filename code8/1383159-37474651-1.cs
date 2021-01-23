    public override object OnPreExecuteServiceFilter(IService service, 
        object request, IRequest httpReq, IResponse httpRes)
    {
        foreach (var pi in service.GetType().GetPublicProperties())
        {
            var mi = pi.GetGetMethod();
            if (mi == null)
                continue;
            var dep = mi.Invoke(service, new object[0]);
            var requiresRequest = dep as IRequiresRequest;
            if (requiresRequest != null)
            {
                requiresRequest.Request = httpReq;
            }
        }
        return base.OnPreExecuteServiceFilter(service, request, httpReq, httpRes);
    }
