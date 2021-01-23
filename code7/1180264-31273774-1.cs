    private string username
        {
            get{
                HttpContext ctx = HttpContext.Current;
                string authHeader = ctx.Request.Headers["Authorization"];
                Encoding encoding = Encoding.GetEncoding("iso-8859-1");
                string encodedUsernamePassword = authHeader.Substring("Basic ".Length).Trim();
                string usernamePassword = encoding.GetString(Convert.FromBase64String(encodedUsernamePassword));
                int seperatorIndex = usernamePassword.IndexOf(':');
                return usernamePassword.Substring(0, seperatorIndex);
            }
        }
