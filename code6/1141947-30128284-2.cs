    using (HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse)
                        {
                            if (response != null && response.StatusCode != HttpStatusCode.OK)
                                throw new Exception(String.Format(
                                    "Server error (HTTP {0}: {1}).",
                                    response.StatusCode,
                                    response.StatusDescription));
    
                            if (response != null)
                            {
                                Stream responseStream = response.GetResponseStream();
    
                                Respose myResponse = GetResponseModel<Response>(responseStream);
    
                             }
                             else throw new Exception("My message");
