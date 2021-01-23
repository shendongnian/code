            try {
                // your code above
            }
            catch(Exception oEx)
            {
                if(oEx.GetType() == typeof(WebException))
                {
                    HttpWebResponse wr = ((WebException)oEx).Response as HttpWebResponse;
                    Stream dataStream = wr.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream, Encoding.UTF8);
                    string str = reader.ReadToEnd(); // str will contain the body of the HTTP 401 response
                    reader.Close();
                }
            }
