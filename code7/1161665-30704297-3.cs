    using System;
    using System.Net;
    using System.Threading;
    using System.IO;
    
    namespace MyNameSpace
    {
        public class Program
        {    
            static void Main(string[] args)
            {
                Thread thread = new Thread(StartListening);
    
                thread.Start();
            }
    
            private static void StartListening()
            {
                HttpListener listener = new HttpListener();
    
                SetPrefixes(listener);
    
                if (listener.Prefixes.Count > 0)
                {
                    listener.Start();
    
                    while (true)
                    {
                        HttpListenerContext context = listener.GetContext();
                        HttpListenerRequest request = context.Request;
    
                        String url = request.RawUrl;
                        String[] queryStringArray = url.Split('/');
    
                        string postedText = GetPostedText(request);
    
                        HttpListenerResponse response = context.Response;
    
                        byte[] buffer = null;
    
                        if (queryStringArray[1] == "myForm")
                        {
                            buffer = System.Text.Encoding.UTF8.GetBytes("I received myForm");
                        }
                        
                        if (queryStringArray[2] == "doSomething")
                        {
                            buffer = System.Text.Encoding.UTF8.GetBytes("I received doSomething");
                        }
    
                        if (buffer != null)
                        {
                            response.AddHeader("Cache-Control", "no-cache");
                            response.AddHeader("Access-Control-Allow-Origin", "*");
    
                            response.ContentLength64 = buffer.Length;
                            Stream outputStream = response.OutputStream;
                            outputStream.Write(buffer, 0, buffer.Length);
                            outputStream.Close();
                        }
                    }
                }
            }
    
            private static void SetPrefixes(HttpListener listener)
            {
                String[] prefixes = new String[] { "http://localhost:8000/" };
    
                int i = 0;
    
                foreach (string s in prefixes)
                {
                    listener.Prefixes.Add(s);
                    i++;
                }
            }
    
            private static string GetPostedText(HttpListenerRequest request)
            {
                string text = "";
    
                using (StreamReader reader = new StreamReader(request.InputStream, request.ContentEncoding))
                {
                    text = reader.ReadToEnd();
                }
    
                return text;
            }
        }
    }
