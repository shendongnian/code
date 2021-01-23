        public bool Url_checker(string link)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(link.Trim()) as HttpWebRequest;
                request.Method = "HEAD";
               
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    return (response.StatusCode == HttpStatusCode.OK);
                }
            }
            catch (WebException)
            {
                return false;
            }
        }
