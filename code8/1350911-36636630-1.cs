    public static bool URLExists(string url)
            {
                HttpStatusCode result = default(HttpStatusCode);
    
                var request =(HttpWebRequest)WebRequest.Create(url);
                request.AllowAutoRedirect = false;
                request.Method = "HEAD";
                try
                {
                    using (var response = request.GetResponse() as HttpWebResponse)
                    {
                        if (response != null)
                        {
                            if (response.StatusCode == HttpStatusCode.OK)
                                return true;
                            if (response.StatusCode == HttpStatusCode.Redirect)
                            {
                                string uriString = request.Headers["Location"];
                                return URLExists(uriString);
                            }
    
                            response.Close();
                        }
                    }
                    return false;
                }
                catch (WebException e)
                {
                    using (WebResponse response = e.Response)
                    {
                        HttpWebResponse httpResponse = (HttpWebResponse)response;
                        Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                        return false;
                    }
                }
            }
