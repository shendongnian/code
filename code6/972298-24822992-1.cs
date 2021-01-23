    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.securedlink.com/fileupload.php");
            HttpHeader a = Config.GetCred;
            request.Headers[a.Key] = a.Value;
            request.Method = "POST";
            request.Credentials = new NetworkCredential("username", "pswd");
            request.BeginGetRequestStream
            ((result =>
                {
                    using (Stream requestStream = request.EndGetRequestStream(result))
                    {
                        using (StreamWriter writer = new StreamWriter(requestStream))
                        {
                            writer.Write(str);
                            writer.Flush();
                        }
                    }
                    request.BeginGetResponse((responseResult =>
                        {
                            try
                            {
                                var webResponse = (HttpWebResponse)request.EndGetResponse(responseResult); 
                                using (var responseStream = webResponse.GetResponseStream())
                                {
                                    using (var streamReader = new StreamReader(responseStream))
                                    {
                                        string srresult = streamReader.ReadToEnd(); 
                                        Debug.WriteLine(srresult);
                                    }
                                }
                            }
                            catch (WebException ex)     
                            {
                                using (StreamReader reader = new StreamReader(ex.Response.GetResponseStream()))
                                {
                                    string ssresult = reader.ReadToEnd();
                                    Debug.WriteLine(ssresult);  
                                }
                            }
                        }), null);
                }), null);
