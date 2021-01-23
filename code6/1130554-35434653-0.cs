    class Program
    {
        private static HttpListener listener;
        static string[] uris =
            {
                "http://localhost:8086/nisse.html",
                "http://localhost:8086/kalle.html",
            };
        private static void ListenerCallback(IAsyncResult result)
        {
            var context = listener.EndGetContext(result);
            HttpListenerRequest request = context.Request;            
            HttpListenerResponse response = context.Response;
            //Maybe not use exact string matching here
            if (uris.Contains(request.Url.ToString()))
            {                
                context.Response.StatusCode = 200;
                context.Response.StatusDescription = "OK";
                string responseString = "<HTML><BODY> YOU ASKED FOR:" + request.Url + "</BODY></HTML>";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                response.ContentLength64 = buffer.Length;
                System.IO.Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                output.Close();
                context.Response.Close();
            }
            else
            {
                context.Response.StatusCode = 404;
                context.Response.StatusDescription = "NOT FOUND";
                context.Response.Close();
            }
        }
        private static void Main()
        {                 
            listener = new HttpListener();  
            //Add the distinct prefixes, you may want ot parse this in a more elegant way
            foreach (string s in uris.Select(u=>u.Substring(0,u.LastIndexOf("/")+1)).Distinct())
            {
                listener.Prefixes.Add(s);
            }
            listener.Start();
            while (true)
            {
                var result = listener.BeginGetContext(ListenerCallback, listener);
                result.AsyncWaitHandle.WaitOne();
            }
        }
    }
