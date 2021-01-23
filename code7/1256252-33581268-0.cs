    public interface IClient { }
    #if WINDOWS_PHONE_APP
    public interface IWebAuthenticationContinuable
    {
        void ContinueWebAuthentication(WebAuthenticationBrokerContinuationEventArgs args);
    }
    #endif
    public class Client : IDisposable, IClient
    #if WINDOWS_PHONE_APP
        , IWebAuthenticationContinuable
    #endif
    {
    #if WINDOWS_PHONE_APP
        public void ContinueWebAuthentication(WebAuthenticationBrokerContinuationEventArgs args) { }
    #endif
        public void DoStuff()
        {
        }
        public void Dispose()
        {
        }
    }
