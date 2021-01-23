     private string GetCacheKey(MethodInterceptionArgs args)
            {
                //need to exclude paging Parameters from Key
    
                var builder = new StringBuilder();
    
                var returnKey = new ViewrCacheKey { CallingMethodFullName = args.Method.ToString() };
    
                // Loop through the Call arguments / parameters
                foreach (var argument in args.Arguments)
                {
                    if (argument != null)
                    {
                        if ((IgnoreParameters == null) ||
                            (IgnoreParameters != null && !IgnoreParameters.Contains(argument.ToString())))
                            builder.Append(JsonConvert.SerializeObject(argument));
                    }
                }
    
                returnKey.ControllerHash = builder.ToString();
    
                return JsonConvert.SerializeObject(returnKey);
            }
