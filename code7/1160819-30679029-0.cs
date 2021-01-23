    HttpWebResponse httpResponse;
                try
                {
                    httpResponse = (HttpWebResponse)httpReq.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        result = streamReader.ReadToEnd();
                    }
                }
                catch (WebException e)
                {
                    Console.WriteLine("This program is expected to throw WebException on successful run." +
                                        "\n\nException Message :" + e.Message);
                    if (e.Status == WebExceptionStatus.ProtocolError)
                    {
                        Console.WriteLine("Status Code : {0}", ((HttpWebResponse)e.Response).StatusCode);
                        Console.WriteLine("Status Description : {0}", ((HttpWebResponse)e.Response).StatusDescription);
                        using (Stream data = e.Response.GetResponseStream())
                        using (var reader = new StreamReader(data))
                        {
                            string text = reader.ReadToEnd();
                            Console.WriteLine(text);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
