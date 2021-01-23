    public class ValidateIpAttribute : RequestFilterAttribute 
    {
        public IpValidator IpValidator { get; set; }
        public void RequestFilter(IRequest req, IResponse res, object requestDto)
        {
            if (IpValidator.Allow(req.RemoteIp))
                return;
    
            res.ContentType = req.ResponseContentType;
            res.StatusCode = (int)HttpStatusCode.Unauthorized;
            res.Dto = DtoUtils.CreateErrorResponse("401", "Unauthorized", null);
            res.EndRequest();
        }
    }
