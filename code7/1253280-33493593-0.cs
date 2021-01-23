    public class WebServer
    {
        public WebServer()
        {
        }
        void Process(object o)
        {
            HttpListenerContext context = o as HttpListenerContext;
            HttpListenerResponse response = context.Response;
            try
            {
                string json;
                string url = context.Request.Url.ToString();
                if (url.Contains("http://localhost:8888/json"))
                {
                    //Returning JSON
                    List<string> list = new List<string>();
                    json = JsonConvert.SerializeObject(new
                    {
                        results = list
                    });
                    byte[] decryptedbytes = new byte[0];
                    decryptedbytes = System.Text.Encoding.UTF8.GetBytes(json);
                    response.AddHeader("Content-type", "text/json");
                    response.ContentLength64 = decryptedbytes.Length;
                    System.IO.Stream output = response.OutputStream;
                    try
                    {
                        output.Write(decryptedbytes, 0, decryptedbytes.Length);
                        output.Close();
                    }
                    catch (Exception e)
                    {
                        response.StatusCode = 500;
                        response.StatusDescription = "Server Internal Error";
                        response.Close();
                        Console.WriteLine(e.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.StatusDescription = "Server Internal Error";
                response.Close();
                Console.WriteLine(ex);
            }
        }
        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
        public void Start()
        {
            HttpListener server = new HttpListener();
            server.Prefixes.Add("http://localhost:8888/json");
            server.Start();
            while (true)
            {
                ThreadPool.QueueUserWorkItem(Process, server.GetContext());  
            }
        }
    }
