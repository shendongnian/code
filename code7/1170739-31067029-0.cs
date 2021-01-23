    /// <summary>
    /// Modified class from:
    /// http://blogs.msdn.com/b/daniem/archive/2013/02/27/digest-authentication-in-system-net-classes-not-compliant-with-rfc2617.aspx
    /// 
    /// Added parameter: opaque
    /// Removed parameter: md5, Alogrithm (no md5 algorithm in answer)
    /// </summary>
    public class DigestHttpWebRequest
    {
        private string _user;
        private string _password;
        private string _realm;
        private string _nonce;
        private string _qop;
        private string _cnonce;
        private string _opaque;
        private DateTime _cnonceDate;
        private int _nc;
        private string _requestMethod = WebRequestMethods.Http.Get;
        private string _contentType;
        private byte[] _postData;
        public DigestHttpWebRequest(string user, string password)
        {
            _user = user;
            _password = password;
        }
        public DigestHttpWebRequest(string user, string password, string realm)
        {
            _user = user;
            _password = password;
            _realm = realm;
        }
        public string Method
        {
            get { return _requestMethod; }
            set { _requestMethod = value; }
        }
        public string ContentType
        {
            get { return _contentType; }
            set { _contentType = value; }
        }
        public byte[] PostData
        {
            get { return _postData; }
            set { _postData = value; }
        }
        public HttpWebResponse GetResponse(Uri uri)
        {
            HttpWebResponse response = null;
            int infiniteLoopCounter = 0;
            int maxNumberAttempts = 2;
            while ((response == null ||
                response.StatusCode != HttpStatusCode.Accepted) &&
                infiniteLoopCounter < maxNumberAttempts)
            {
                try
                {
                    var request = CreateHttpWebRequestObject(uri);
                    // If we've got a recent Auth header, re-use it!
                    if (!string.IsNullOrEmpty(_cnonce) &&
                        DateTime.Now.Subtract(_cnonceDate).TotalHours < 1.0)
                    {
                        request.Headers.Add("Authorization", ComputeDigestHeader(uri));
                    }
                    try
                    {
                        response = (HttpWebResponse)request.GetResponse();
                    }
                    catch (WebException webException)
                    {
                        // Try to fix a 401 exception by adding a Authorization header
                        if (webException.Response != null &&
                            ((HttpWebResponse)webException.Response).StatusCode == HttpStatusCode.Unauthorized)
                        {
                            var wwwAuthenticateHeader = webException.Response.Headers["WWW-Authenticate"];
                            _realm = GetDigestHeaderAttribute("realm", wwwAuthenticateHeader);
                            _nonce = GetDigestHeaderAttribute("nonce", wwwAuthenticateHeader);
                            _qop = GetDigestHeaderAttribute("qop", wwwAuthenticateHeader);
                            _opaque = GetDigestHeaderAttribute("opaque", wwwAuthenticateHeader);
                            _nc = 0;
                            _cnonce = new Random().Next(123400, 9999999).ToString();
                            _cnonceDate = DateTime.Now;
                            request = CreateHttpWebRequestObject(uri, true);
                            infiniteLoopCounter++;
                            response = (HttpWebResponse)request.GetResponse();
                        }
                        else
                        {
                            throw webException;
                        }
                    }
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.OK:
                        case HttpStatusCode.Accepted:
                            return response;
                        case HttpStatusCode.Redirect:
                        case HttpStatusCode.Moved:
                            uri = new Uri(response.Headers["Location"]);
                            // We decrement the loop counter, as there might be a variable number of redirections which we should follow
                            infiniteLoopCounter--;
                            break;
                    }
                }
                catch (WebException ex)
                {
                    throw ex;
                }
            }
            throw new Exception("Error: Either authentication failed, authorization failed or the resource doesn't exist");
        }
        private HttpWebRequest CreateHttpWebRequestObject(Uri uri, bool addAuthenticationHeader)
        {
            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.AllowAutoRedirect = true;
            request.PreAuthenticate = true;
            request.Method = this.Method;
            ///Only for test reason. The Ip is the one for fiddler
            //request.Proxy = new WebProxy("127.0.0.1:8888", true);
            if (!String.IsNullOrEmpty(this.ContentType))
            {
                request.ContentType = this.ContentType;
            }
            if (addAuthenticationHeader)
            {
                request.Headers.Add("Authorization", ComputeDigestHeader(uri));
            }
            if (this.PostData != null && this.PostData.Length > 0)
            {
                request.ContentLength = this.PostData.Length;
                Stream postDataStream = request.GetRequestStream(); //open connection
                postDataStream.Write(this.PostData, 0, this.PostData.Length); // Send the data.
                postDataStream.Close();
            }
            else if (
                this.Method == WebRequestMethods.Http.Post &&
                (this.PostData == null || this.PostData.Length == 0))
            {
                request.ContentLength = 0;
            }
            return request;
        }
        private HttpWebRequest CreateHttpWebRequestObject(Uri uri)
        {
            return CreateHttpWebRequestObject(uri, false);
        }
        private string ComputeDigestHeader(Uri uri)
        {
            _nc = _nc + 1;
            string ha1, ha2;
            ha1 = ComputeMd5Hash(string.Format("{0}:{1}:{2}", _user, _realm, _password));
            ha2 = ComputeMd5Hash(string.Format("{0}:{1}", this.Method, uri.PathAndQuery));
            var digestResponse =
                ComputeMd5Hash(string.Format("{0}:{1}:{2:00000000}:{3}:{4}:{5}", ha1, _nonce, _nc, _cnonce, _qop, ha2));
            return string.Format("Digest username=\"{0}\",realm=\"{1}\",nonce=\"{2}\",uri=\"{3}\"," +
                "cnonce=\"{7}\",nc={6:00000000},qop={5},response=\"{4}\",opaque=\"{8}\"",
                _user, _realm, _nonce, uri.PathAndQuery, digestResponse, _qop, _nc, _cnonce, _opaque);
            throw new Exception("The digest header could not be generated");
        }
        private string GetDigestHeaderAttribute(string attributeName, string digestAuthHeader)
        {
            var regHeader = new Regex(string.Format(@"{0}=""([^""]*)""", attributeName));
            var matchHeader = regHeader.Match(digestAuthHeader);
            if (matchHeader.Success)
                return matchHeader.Groups[1].Value;
            throw new ApplicationException(string.Format("Header {0} not found", attributeName));
        }
        private string ComputeMd5Hash(string input)
        {
            var inputBytes = Encoding.ASCII.GetBytes(input);
            var hash = MD5.Create().ComputeHash(inputBytes);
            var sb = new StringBuilder();
            foreach (var b in hash)
                sb.Append(b.ToString("x2"));
            return sb.ToString();
        }
    }
