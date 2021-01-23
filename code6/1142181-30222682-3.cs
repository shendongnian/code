    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.Text;
    using System.Web;
    using System.Web.Hosting;
    using System.Web.Security;
    using System.Web.Configuration;
    using System.Configuration;
    using System.IO;
    using System.Security.Permissions;
    using System.Security.Principal;
    using System.ServiceModel.Activation;
    using System.Threading;
    namespace Microsoft.ServiceModel.Samples
    {
	    public class IsolatedAuthService : IIsolatedAuthService
    	{
            public string IsAuthorized(string username, string roleName)
            {
                MembershipUser user = Membership.GetAllUsers()[username];
                Configuration config = ConfigurationManager.OpenExeConfiguration(HostingEnvironment.MapPath("~") + "\\web.config");           
                SessionStateSection sessionStateConfig = (SessionStateSection)config.SectionGroups.Get("system.web").Sections.Get("sessionState");
                // Check for session state timeout (could use a constant here instead if you don't want to rely on the config).
                if (user.LastLoginDate.AddMinutes(sessionStateConfig.Timeout.TotalMinutes) < DateTime.Now)
                    return "User Unauthorized - login has expired!";
                // Check for role membership.
                if (!Roles.GetUsersInRole(roleName).Contains(user.UserName))
                    return "User Unauthorized - Does not belong in that role!";
                return "Success - User is Authorized!";
            }
            public string AuthenticateUser(string username, string encryptedPassword)
            {
                if (Membership.ValidateUser(username, Decrypt(encryptedPassword)))
                {
                    // Not sure if this is actually needed, but reading some documentation I think it's a safe bet to do here anyway.
                    Membership.GetAllUsers()[username].LastLoginDate = DateTime.Now;
                    // Send back a token!
                    Guid token = Guid.NewGuid();
                    // Store a token for this username.
                    InMemoryInstances instance = InMemoryInstances.Instance;
					instance.removeTokenUserPair(username); //Because we don't implement a "Logout" method.
                    instance.addTokenUserPair(username, token.ToString());
                    return token.ToString();
                }
                return "Error - User was not able to be validated!";
            }
        }
    }
