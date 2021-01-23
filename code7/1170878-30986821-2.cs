        public void MethodOne()
        {
            MethodTwo(response =>
                {
                    if (response is FooException)
                    {
                        FooException exc = response as FooException;
                    }
                    else
                    {
                        // Handle response;
                    }
                });
        }
        public void MethodTwo(Action<object> callback)
        {
            //Conduct async call to external server 
            AppServer.MakeCall(response =>
            {
                if (Response.IsValid)
                    callback(Response.Object);
                else
                    callback(new FooException());
            });
        }
