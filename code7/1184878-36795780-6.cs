    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Remoting.Messaging;
    using System.Text;
    using System.Threading.Tasks;
    namespace Web.Api.Host
    {
        public interface IOwinRequestScopeContext
        {
            IDictionary<string, object> Items { get; }
            DateTime Timestamp { get; }
            void EndRequest();
        }
        public class OwinRequestScopeContext : IOwinRequestScopeContext
        {
            const string c_callContextKey = "owin.reqscopecontext";
            private readonly DateTime _utcTimestamp = DateTime.UtcNow;
            private ConcurrentDictionary<string, object> _items = new ConcurrentDictionary<string, object>();
            /// <summary>
            /// Gets or sets the <see cref="IOwinRequestScopeContext"/> object 
            /// for the current HTTP request.
            /// </summary>
            public static IOwinRequestScopeContext Current
            {
                get
                {
                    var requestContext = CallContext.LogicalGetData(c_callContextKey) as IOwinRequestScopeContext;
                    if (requestContext == null)
                    {
                        requestContext = new OwinRequestScopeContext();
                        CallContext.LogicalSetData(c_callContextKey, requestContext);
                    }
                    return requestContext;
                }
                set
                {
                    CallContext.LogicalSetData(c_callContextKey, value);
                }
            }
            public void EndRequest()
            {
                CallContext.FreeNamedDataSlot(c_callContextKey);
            }
            public IDictionary<string, object> Items
            {
                get
                {
                    return _items;
                }
            }
            public DateTime Timestamp
            {
                get
                {
                    return _utcTimestamp.ToLocalTime();
                }
            }
        }
    }
