    private string WebServiceCall(string methodname)
        {
            try
            {
                string response = string.Empty;
                Uri uri = new Uri(string.Format("http://{0}:{1}/{2}", _servername, _port, methodname));
                DigestHttpWebRequest req = new DigestHttpWebRequest(_username, _password);
                using (HttpWebResponse webResponse = req.GetResponse(uri))
                using (Stream responseStream = webResponse.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader streamReader = new StreamReader(responseStream))
                        {
                            response = streamReader.ReadToEnd();
                        }
                    }
                }
                return response;
            }
            catch (WebException caught)
            {
                throw new WebException(string.Format("Exception in WebServiceCall: {0}", caught.Message));
            }
            catch (Exception caught)
            {
                throw new Exception(string.Format("Exception in WebServiceCall: {0}", caught.Message));
            }
        }
