    string authHeader = WebClient.Headers[HttpRequestHeader.Authorization];
            if (authHeader != null && authHeader.StartsWith("Basic"))
            {
                Encoding encoding = Encoding.GetEncoding("iso-8859-1");
                string encodedUsernamePassword = authHeader.Substring("Basic ".Length).Trim();
                string usernamePassword = encoding.GetString(Convert.FromBase64String(encodedUsernamePassword));
                int seperatorIndex = usernamePassword.IndexOf(':');
                return usernamePassword.Substring(0, seperatorIndex);
            }
