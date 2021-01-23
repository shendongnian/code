        public int secret_key;
        public string session_token; //is a token used to authorize user specific transactions
        public string time;
        bool first_call = true;
        bool new_key = false;
            //Creating a first session token MediaFire 
            string email = "";
            string password = "";
            string app_id = "";
            string app_key = "";
            byte[] b = Encoding.UTF8.GetBytes(email + password + app_id + app_key);
            SHA1 sh = new SHA1Managed();
            byte[] b2 = sh.ComputeHash(b);
            string signature = BitConverter.ToString(b2).Replace("-", "").ToLower();
            string req_url = String.Format("https://www.mediafire.com/api/1.4/user/get_session_token.php?email={0}&password={1}&application_id={2}&signature={3}&token_version=2", email, password, app_id, signature);
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(req_url);
            try
            {
                WebResponse response = myReq.GetResponse();
                Stream responseStream = response.GetResponseStream();
                XElement root = XDocument.Load(responseStream).Root;
                if (root.Element("result").Value == ("Success"))
                {
                    secret_key = Convert.ToInt32(root.Element("secret_key").Value);
                    session_token = root.Element("session_token").Value;
                    time = root.Element("time").Value;
                }
                else if (root.Element("result").Value == ("Error"))
                {
                    //TODO
                    //Check errors list on MediaFire API
                    int error = Convert.ToInt32(root.Element("error").Value);
                    string message_error = root.Element("message").Value;
                }
            }
            catch (System.Net.WebException webEx)
            {
                HttpWebResponse response = webEx.Response as HttpWebResponse;
                if (response.StatusCode == HttpStatusCode.Forbidden)
                {
                    var r_error = (HttpWebResponse)webEx.Response;
                    Stream receiveStream = r_error.GetResponseStream();
                    StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8);
                    string s = reader.ReadToEnd().ToString();
                    XElement response_body = XDocument.Parse(s).Root;
                    int error = Convert.ToInt32(response_body.Element("error").Value);
                    string message_error = response_body.Element("message").Value;
                }
                else if (response.StatusCode != HttpStatusCode.Forbidden)
                {
                    throw;
                }
            }
