        using System.Net; // contains HttpRequestHeader enum
        public static void SetBasicAuthHeader(WebRequest request, String userName, String userPassword)
        {
            string authInfo = userName + ":" + userPassword;
            authInfo = Convert.ToBase64String(Encoding.ASCII.GetBytes(authInfo));
			string authHeader = string.Format("Basic {0}", authInfo);
            request.Headers[HttpRequestHeader.Authorization] = authHeader;
        }
