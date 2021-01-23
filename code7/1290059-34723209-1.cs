        private void SpecAPI()
        {
            var req = (HttpWebRequest)WebRequest.Create("http://www.google.com");
            //req.Method = "HEAD";
            req.BeginGetResponse(
                asyncResult =>
                {
                    var resp = (HttpWebResponse)req.EndGetResponse(asyncResult);
                    var headersText = formatHeaders(resp.Headers);
                    Console.WriteLine(headersText);
                }, null);
        }
        private string formatHeaders(WebHeaderCollection headers)
        {
            var headerString = headers.Keys.Cast<string>()
                                      .Select(header => string.Format("{0}:{1}", header, headers[header]));
            return string.Join(Environment.NewLine, headerString.ToArray());
        }
