        var ws;
        var username = "JOHN";
        function startchat() {
            var log= $('log');
            var url = 'ws://<server path>/WebSocketsServer.ashx?username=' + username;
            
            ws = new WebSocket(url);
            ws.onerror = function (e) {
                log.appendChild(createSpan('Problem with connection: ' + e.message));
            };
            ws.onopen = function () {
                ws.send("I am Active-" +username);
            };
            ws.onmessage = function (e) {
               
                if (e.data.toString() == "Active?") {
                    ws.send("I am Active-" + username);
                }
                else {
                    
                }
            };
            ws.onclose = function () {
                log.innerHTML = 'Closed connection!';
            };
        }
    </script>
</head>
<body>
    
    <div id="log">
    
    </div>
   
</body>
**Server Side in Websocketserver.ashx page**
 public class WebSocketsServer : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest)
            {
                context.AcceptWebSocketRequest(new MicrosoftWebSockets());
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
Add below class in the server side
    public class MicrosoftWebSockets : WebSocketHandler
    {
        private static WebSocketCollection clients = new WebSocketCollection();
        private string msg;
        public override void OnOpen()
        {
            this.msg = this.WebSocketContext.QueryString["username"];
            clients.Add(this);
            clients.Broadcast(msg);
        }
        public override void OnMessage(string message)
        {
            clients.Broadcast(string.Format(message));
        }
        public override void OnClose()
        {
            clients.Remove(this);
            clients.Broadcast(string.Format(msg));
        }
   add this dll to the above class
    using Microsoft.Web.WebSockets;
I donot remeber where I got the reference ...but above code is derived from my current working application
