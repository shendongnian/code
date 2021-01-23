                    HttpWebRequest req = WebRequest.Create(uri) as HttpWebRequest;
                    req.KeepAlive = false;
                    req.Method = Method.ToUpper();
                    if (("POST,PUT").Split(',').Contains(Method.ToUpper()))
                    {
                        content = // here write your content Stream.ReadToEnd() or something similar
                        byte[] buffer = Encoding.ASCII.GetBytes(content);
                        req.ContentLength = buffer.Length;
                        req.ContentType = // write your content type "text/xml";
                        Stream PostData = req.GetRequestStream();
                        PostData.Write(buffer, 0, buffer.Length);
                        PostData.Close();
                    }
                    HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
                    Encoding enc = Encoding.GetEncoding(1252);
                    StreamReader loResponseStream =
                    new StreamReader(resp.GetResponseStream(), enc);
                    string Response = loResponseStream.ReadToEnd();
                    loResponseStream.Close();
