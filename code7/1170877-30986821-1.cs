        public void MethodOne()
        {
            MethodTwo(response =>
                {
                    if (Response.IsValid)
                        callback(Response.Object);
                    else
                        throw new FooException();  // Or error handling directly
                });
        }
        public void MethodTwo(Action<Response> callback)
        {
            //Conduct async call to external server 
            AppServer.MakeCall(response =>
            {
                callback(response);
            });
        }
