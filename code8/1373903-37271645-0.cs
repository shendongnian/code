        class CustomActorServiceRemotingDispatcher : ActorServiceRemotingDispatcher
        {
            public CustomActorServiceRemotingDispatcher(ActorService actorService) : base(actorService)
            {
            }
            public override async Task<byte[]> RequestResponseAsync(IServiceRemotingRequestContext requestContext, ServiceRemotingMessageHeaders messageHeaders,
                byte[] requestBodyBytes)
            {
                    try
                    {
                        LogServiceMethodStart(...);
                        result = await base.RequestResponseAsync(requestContext, messageHeaders, requestBodyBytes).ConfigureAwait(false);
                        LogServiceMethodStop(...);
                        return result;
                    }
                    catch (Exception exception)
                    {
                        LogServiceMethodException(...);
                    
                        throw;
                    }
            }
        }
