    public abstract class WcfWebClient<T> where T : class
    {
        public static TResult InvokeRestMethod<TResult>(Func<T, TResult> method, Binding binding, EndpointAddress address)
        {
            var myChannelFactory = new ChannelFactory<T>(binding, address);
            var wcfClient = myChannelFactory.CreateChannel();
            
            try
            {
                var result = method(wcfClient);
                ((IClientChannel)wcfClient).Close();
                return result;
            }
            catch (TimeoutException e)
            {
                Trace.TraceError("WCF Client Timeout Exception" + e.Message);
                // Handle the timeout exception.
                ((IClientChannel)wcfClient).Abort();
                throw;
            }
            catch (CommunicationException e)
            {
                Trace.TraceError("WCF Client Communication Exception" + e.Message);
                // Handle the communication exception.
                ((IClientChannel)wcfClient).Abort();
                throw;
            }
        }
    }
