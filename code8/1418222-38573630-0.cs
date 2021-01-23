    public interface IServerEvents : IDisposable
    {
        // External API's
        void NotifyAll(string selector, object message);
        void NotifyChannel(string channel, string selector, object message);
        void NotifySubscription(string subscriptionId, string selector, object message, string channel = null);
        void NotifyUserId(string userId, string selector, object message, string channel = null);
        void NotifyUserName(string userName, string selector, object message, string channel = null);
        void NotifySession(string sspid, string selector, object message, string channel = null);
        //..
    }
