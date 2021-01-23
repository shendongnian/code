    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "json=" + "{\"user\":\"test\"," +
                                  "\"password\":\"bla\"}"; ;
    
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
