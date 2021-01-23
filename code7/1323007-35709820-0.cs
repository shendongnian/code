    namespace ReiDoCSharp
    {
        class ShowMessage
        {
            private static RootObject alerta;
            public static bool created;
            private static int startPosition;
            public static void setStartPosition(int start)
            {
                if (start < startPosition)
                {
                    startPosition = start;
                }
            }
            public RootObject getAlerta()
            {
                return ShowMessage.alerta;
            }
            public void setAlerta(RootObject root)
            {
                ShowMessage.alerta = root;
            }
            private static void DoWork()
            {
                while (true)
                {
                    if (created != true)
                    {
                        created = true;
                    }
                    if (alerta != null)
                    {
                        string mensagem = "";
                        if ((alerta.data.Informacoes[1] != "") && (alerta.data.Informacoes[1] != null))
                        {
                            mensagem += alerta.data.Informacoes[1];
                        }
                        if ((alerta.data.Informacoes[0] != "") && (alerta.data.Informacoes[0] != null))
                        {
                            mensagem += alerta.data.Informacoes[0];
                        }
                        if (mensagem != "")
                        {
                            startPosition = 5;
                            string[] messages = mensagem.Split(new[] { "<br><br>" }, StringSplitOptions.None);
                            foreach (string message in messages)
                            {
                                Notification popup = new Notification();
                                popup.label1.Text = message;
                                popup.TopMost = true;
                                popup.Show();
                                Application.DoEvents();
                                /*Solution with the ShowDialog would be:
                                    Task.Run(() => showNotification(message));
                                */
                            }
                        }
                    }
                    Thread.Sleep(5000);
                }
            }
            //Then I won't need to use Application.DoEvents, but would have to create more threads
            private static Task showNotification(string message)
            {
                Notification popup = new Notification();
                popup.label1.Text = message;
                popup.TopMost = true;
                popup.ShowDialog();
            }
            public static Task createPopupsAsync()
            {
                Task.Run(() => DoWork());
            }
        }
    }
    namespace ReiDoCSharp
    {
        class SocketService
        {
            private static object consoleLock = new object();
            private const bool verbose = true;
            private static readonly TimeSpan delay = TimeSpan.FromMilliseconds(3000);
            private static UTF8Encoding encoder = new UTF8Encoding();
            private static string message;
            private static RootObject alerta;
            public SocketService()
            {
                Begin();
            }
            public static void Begin()
            {
                alerta = null;
                while (true)
                {
                    try
                    {
                        Thread.Sleep(2000);
                        Connect("ws://192.168.120.38:9091").Wait();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }
            public static async Task Connect(string uri)
            {
                ClientWebSocket webSocket = null;
                try
                {
                    webSocket = new ClientWebSocket();
                    await webSocket.ConnectAsync(new Uri(uri), CancellationToken.None);
                    await Login(webSocket);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (webSocket != null)
                        webSocket.Dispose();
                    lock (consoleLock)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("WebSocket closed.");
                        Console.ResetColor();
                    }
                }
            }
            private static async Task Login(ClientWebSocket webSocket)
            {
                ArraySegment<Byte> buffer = new ArraySegment<byte>(encoder.GetBytes("{\"event\":\"loginBrowser\",\"data\":{\"OPERADOR\":\"000000003077\",\"NRORG\":\"1\"}}"));
                await webSocket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
                if (webSocket.State == WebSocketState.Open)
                {
                    Task.Factory.StartNew(() => ShowMessage.createPopupsAsync());
                    await Receive(webSocket);
                }
            }
            private static async Task Receive(ClientWebSocket webSocket)
            {
                while (webSocket.State == WebSocketState.Open)
                {
                    ArraySegment<Byte> buffer = new ArraySegment<byte>(new Byte[256]);
                    var result = await webSocket.ReceiveAsync(buffer, CancellationToken.None);
                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                    }
                    else
                    {
                        if (result.EndOfMessage)
                        {
                            message += encoder.GetString(buffer.ToArray());
                            SendMessage(message);
                        }
                        else
                        {
                            message += encoder.GetString(buffer.ToArray());
                        }
                    }
                }
            }
            private static void LogStatus(bool receiving, byte[] buffer, int length, string assunto)
            {
                lock (consoleLock)
                {
                    Console.ForegroundColor = receiving ? ConsoleColor.Green : ConsoleColor.Yellow;
                    if (verbose)
                    {
                        Console.WriteLine(encoder.GetString(buffer) + "  " + assunto);
                    }
                    Console.ResetColor();
                }
            }
            private static void SendMessage(string message)
            {
                message = message.Replace("event", "evento");
                message = message.Replace("\0", "");
                JavaScriptSerializer js = new JavaScriptSerializer();
                RootObject mess = js.Deserialize<RootObject>(message);
                if (mess.data.Informacoes[1] != "")
                {
                    mess.data.Informacoes[1] += "<br>";
                }
                if (alerta == null)
                {
                    alerta = mess;
                }
                else
                {
                    if ((mess.data.Quantidade[0] != 0) && (mess.data.Quantidade == null))
                    {
                        if ((mess.data.Quantidade[0] == -1) && (mess.data.Informacoes[0] == ""))
                        {
                            alerta = null;
                        }
                        else
                        {
                            alerta = mess;
                        }
                    }
                    else if (mess.data.Quantidade[0] == 0)
                    {
                        alerta = null;
                    }
                    if ((mess.data.Quantidade[1] != 0) && (mess.data.Informacoes[1] != ""))
                    {
                        alerta = mess;
                    }
                }
                
                new ShowMessage().setAlerta(alerta);
                message = "";
            }
        }
    }
