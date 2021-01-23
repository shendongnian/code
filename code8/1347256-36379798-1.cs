    var request = (HttpWebRequest)WebRequest.Create(EndPoint);
            request.Method = Method.ToString();
            request.ContentLength = 0;
            request.ContentType = ContentType;
            
            Console.WriteLine("request: " + request.Headers.ToString());
            if (PostData != null && Method == HttpVerb.POST)
            {
                Console.WriteLine("json length: " + json.Length);
                Console.WriteLine(json);
                request.ContentLength = json.Length;
                var encoding = new UTF8Encoding();             
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
            }
            try
            {
                // ****    FIRST READ USING request.GetResponse()    ****
                //var httpResponse = (HttpWebResponse)request.GetResponse();
                //using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                //{
                //    streamReader.ReadToEnd();
                //}
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    var responseValue = string.Empty;
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        var message = String.Format("Request failed. Received HTTP {0}", response.StatusCode);
                        throw new ApplicationException(message);
                    }
                    // grabs the response
                    using (var responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                            using (var reader = new StreamReader(responseStream))
                            {
                                //  ****    SECOND READ USING response.GetResponseStream()    ****
                                responseValue = reader.ReadToEnd();
                            }
                    }
                    return responseValue;
                }
            }
