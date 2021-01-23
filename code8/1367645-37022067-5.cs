    using MvcUsernameInUrl.Models;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Web;
    using System.Web.Caching;
    using System.Web.Routing;
    namespace MvcUsernameInUrl
    {
        public class OwinUsernameConstraint : IRouteConstraint
        {
            private object synclock = new object();
            public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
            {
                if (parameterName == null)
                    throw new ArgumentNullException("parameterName");
                if (values == null)
                    throw new ArgumentNullException("values");
                object value;
                if (values.TryGetValue(parameterName, out value) && value != null)
                {
                    string valueString = Convert.ToString(value, CultureInfo.InvariantCulture);
                    return this.GetUsernameList(httpContext).Contains(valueString);
                }
                return false;
            }
            private IEnumerable<string> GetUsernameList(HttpContextBase httpContext)
            {
                string key = "UsernameConstraint.GetUsernameList";
                var usernames = httpContext.Cache[key];
                if (usernames == null)
                {
                    lock (synclock)
                    {
                        usernames = httpContext.Cache[key];
                        if (usernames == null)
                        {
                            // Retrieve the list of usernames from the database
                            using (var db = ApplicationDbContext.Create())
                            {
                                usernames = (from users in db.Users
                                                select users.UserName).ToList();
                            }
                            
                            httpContext.Cache.Insert(
                                key: key,
                                value: usernames,
                                dependencies: null,
                                absoluteExpiration: Cache.NoAbsoluteExpiration,
                                slidingExpiration: TimeSpan.FromSeconds(15),
                                priority: CacheItemPriority.NotRemovable,
                                onRemoveCallback: null);
                        }
                    }
                }
                return (IEnumerable<string>)usernames;
            }
        }
    }
