     public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            HttpRequestMessage request = context.Request;
            var content = request.Content.ReadAsAsync(typeof(Object)).Result.ToString();
            var methodInfo = ((ReflectedHttpActionDescriptor)request.Properties["MS_HttpActionDescriptor"]).MethodInfo; // get the method descriptor
            if (methodInfo.GetParameters().Any())  //this will get the parameter types
            {
                 var parameterType = methodInfo.GetParameters().First().ParameterType; //you iterate can through the parameters if you need
                 var casted = Json.Decode(content, parameterType);  //convert the json content into the previous type (your parameter)
                 //do something with your populated object :)
            }
            return Task.FromResult(context.Request);
        }
