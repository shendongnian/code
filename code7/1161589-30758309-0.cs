            if (Request.Properties.ContainsKey("MS_HttpContext"))
            {
                HttpContextWrapper HttpContext = (HttpContextWrapper)Request.Properties["MS_HttpContext"];
                if (HttpContext != null)
                {
                    if (HttpContext.IsWebSocketRequest)
                    {
                        HttpContext.AcceptWebSocketRequest(SomeFunction);
                    }
                }
            }
