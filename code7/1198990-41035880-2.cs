     private UserLogin GetUserLoginCredentials()
        {
            HttpContext httpContext = HttpContext.Current;
            UserLogin userLogin;
            string authHeader = httpContext.Request.Headers["Authorization"];
            if (authHeader != null && authHeader.StartsWith("Basic"))
            {
                string encodedUsernamePassword = authHeader.Substring("Basic ".Length).Trim();
                Encoding encoding = Encoding.GetEncoding("iso-8859-1");
                string usernamePassword = encoding.GetString(Convert.FromBase64String(encodedUsernamePassword));
                int seperatorIndex = usernamePassword.IndexOf(':');
                userLogin = new UserLogin()
                {
                    Username = usernamePassword.Substring(0, seperatorIndex),
                    Password = usernamePassword.Substring(seperatorIndex + 1)
                };
            }
            else
            {
                //Handle what happens if that isn't the case
                throw new Exception("The authorization header is either empty or isn't Basic.");
            }
            return userLogin;
        }
