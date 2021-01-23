    OperationContext context = OperationContext.Current;
    
                if (context != null)
                {
                    try
                    {
                        _LoginName = OperationContext.Current.IncomingMessageHeaders.GetHeader<string>("String", "System");          
                    }
                    catch
                    {
                        _LoginName = string.Empty;
                    }
                }
  
