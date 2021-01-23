        public IActionResult Index()
        {
            var feature = HttpContext.Features[typeof(IHttpConnectionFeature)] as IHttpConnectionFeature;
            if (feature != null)
            {
                var address = feature.RemoteIpAddress; // Request.UserHostAddress
            }
            
            var userAgent = Request.Headers["User-Agent"].FirstOrDefault(); // Request.UserAgent
            return View();
        }
