    public static class HttpResponseBaseExtensions
    {
        public static int SetAuthCookie<T>(this HttpResponseBase responseBase, string name, bool rememberMe, T userData)
        {
            HttpCookie cookie = FormsAuthentication.GetAuthCookie(name, rememberMe);
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
            if (ticket != null)
            {
                FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration,
                    ticket.IsPersistent, JsonConvert.SerializeObject(userData), ticket.CookiePath);
                string encTicket = FormsAuthentication.Encrypt(newTicket);
                cookie.Value = encTicket;
                responseBase.Cookies.Add(cookie);
                return encTicket != null ? encTicket.Length : 0;
            }
            return 0;
        }        
    }
