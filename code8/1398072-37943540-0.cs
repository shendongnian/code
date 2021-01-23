    public DataTable readXML(string postcode, string response, string accessCode)
     {
            //Create URL
            string url = $"http://pcls1.craftyclicks.co.uk/xml/rapidaddress?postcode={postcode}&response={response}&key={accessCode}";
    DataTable dataTableresult  = null;
    
            try
                //Create WebRequest
                WebRequest request = WebRequest.Create(url);
                using (Stream responseStream = request.GetResponse().GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (TextReader textReader = new StreamReader(responseStream))
                        {
                            XmlTextReader reader = new XmlTextReader(textReader);
                            Debug.Assert(reader != null, "Reader is NULL");
                            dataTableresult =  returnAddressList(postcode,response,reader  )
                            return reader;
                        }
                    }
                    throw new Exception("ResponseStream is NULL");
                }
            }
            catch (WebException ex)
            {
                return null;
            }
