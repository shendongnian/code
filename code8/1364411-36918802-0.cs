     public MainWindow()
            {
                InitializeComponent();
                System.Net.HttpListener listener = new System.Net.HttpListener();
                listener.Prefixes.Add("http://localhost:8040/");  
                listener.Start();
                listener.BeginGetContext(RequestCallback, listener);  
            }
    
     private void RequestCallback(IAsyncResult ar)
            {
                HttpListener listener = (HttpListener) ar.AsyncState;
                var context = listener.EndGetContext(ar);
                var userAgent = context.Request.UserAgent;
                var responseMsg = "Hello " + userAgent;
                var responseMsgBytes = Encoding.UTF8.GetBytes(responseMsg);
                context.Response.ContentLength64 = responseMsgBytes.Length;  //Response msg size
                context.Response.OutputStream.Write(responseMsgBytes,0,responseMsgBytes.Length);
                context.Response.OutputStream.Close();
                listener.BeginGetContext(RequestCallback, listener);  //Enable new requests
            }
