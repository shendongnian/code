    using System.Threading;
    using System.Web;
    
    namespace SomeNamespace.Server.ServerCommon.Utility
    {
        /// <summary>
        /// Preserve HttpContext.Current across async/await calls.  
        /// Usage: Set it at beginning of request and clear at end of request.
        /// </summary>
        static public class HttpContextProvider
        {
            /// <summary>
            /// Property to help ensure a non-null HttpContext.Current.
            /// Accessing the property will also set the original HttpContext.Current if it was null.
            /// </summary>
            static public HttpContext Current => HttpContext.Current ?? (HttpContext.Current = __httpContextAsyncLocal?.Value);
    
            /// <summary>
            /// MVC5 does not preserve HttpContext across async/await calls.  This can be used as a fallback when it is null.
            /// It is initialzed/cleared within BeginRequest()/EndRequest()
            /// MVC6 may have resolved this issue since constructor DI can pass in an HttpContextAccessor.
            /// </summary>
            static private AsyncLocal<HttpContext> __httpContextAsyncLocal = new AsyncLocal<HttpContext>();
    
            /// <summary>
            /// Make the current HttpContext.Current available across async/await boundaries.
            /// </summary>
            static public void OnBeginRequest()
            {
                __httpContextAsyncLocal.Value = HttpContext.Current;
            }
    
            /// <summary>
            /// Stops referencing the current httpcontext
            /// </summary>
            static public void OnEndRequest()
            {
                __httpContextAsyncLocal.Value = null;
            }
        }
    }
