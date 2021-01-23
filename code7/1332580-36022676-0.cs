    using System;
    using System.Net.WebSockets;
    using System.Net;
    using System.Runtime.Serialization.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Text;
    using System.IO;
    using System.Runtime.Serialization;
    
    
    // Perform streaming transcription of an audio file using the IBM Watson Speech to Text service over a websocket
    // http://www.ibm.com/smarterplanet/us/en/ibmwatson/developercloud/speech-to-text.html
    // https://msdn.microsoft.com/en-us/library/system.net.websockets.clientwebsocket%28v=vs.110%29.aspx
    namespace WatsonSTTWebsocketExample
    {
    
        class Program
        {
    
            static void Main(string[] args)
            {
                Transcribe();
                Console.WriteLine("Press any key to exit");
                Console.ReadLine();
            }
    
            // http://www.ibm.com/smarterplanet/us/en/ibmwatson/developercloud/doc/getting_started/gs-credentials.shtml
            static String username = "<username>";
            static String password = "<password>";
    
            static String file = @"c:\audio.wav";
    
            static Uri url = new Uri("wss://stream.watsonplatform.net/speech-to-text/api/v1/recognize");
            static ArraySegment<byte> openingMessage = new ArraySegment<byte>( Encoding.UTF8.GetBytes(
                "{\"action\": \"start\", \"content-type\": \"audio/wav\", \"continuous\" : true, \"interim_results\": true}"
            ));
            static ArraySegment<byte> closingMessage = new ArraySegment<byte>(Encoding.UTF8.GetBytes(
                "{\"action\": \"stop\"}"
            ));
    
    
            static void Transcribe()
            {
                var ws = new ClientWebSocket();
                ws.Options.Credentials = new NetworkCredential(username, password);
                ws.ConnectAsync(url, CancellationToken.None).Wait();
    
                // send opening message and wait for initial delimeter 
                Task.WaitAll(ws.SendAsync(openingMessage, WebSocketMessageType.Text, true, CancellationToken.None), HandleResults(ws));
    
                // send all audio and then a closing message; simltaneously print all results until delimeter is recieved
                Task.WaitAll(SendAudio(ws), HandleResults(ws)); 
    
                // close down the websocket
                ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "Close", CancellationToken.None).Wait();
            }
    
            static async Task SendAudio(ClientWebSocket ws)
            {
                
                using (FileStream fs = File.OpenRead(file))
                {
                    byte[] b = new byte[1024];
                    while (fs.Read(b, 0, b.Length) > 0)
                    {
                        await ws.SendAsync(new ArraySegment<byte>(b), WebSocketMessageType.Binary, true, CancellationToken.None);
                    }
                    await ws.SendAsync(closingMessage, WebSocketMessageType.Text, true, CancellationToken.None);
                }
            }
    
            // prints results until the connection closes or a delimeterMessage is recieved
            static async Task HandleResults(ClientWebSocket ws)
            {
                var buffer = new byte[1024];
                while (true)
                {
                    var segment = new ArraySegment<byte>(buffer);
    
                    var result = await ws.ReceiveAsync(segment, CancellationToken.None);
    
                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        return;
                    }
    
                    int count = result.Count;
                    while (!result.EndOfMessage)
                    {
                        if (count >= buffer.Length)
                        {
                            await ws.CloseAsync(WebSocketCloseStatus.InvalidPayloadData, "That's too long", CancellationToken.None);
                            return;
                        }
    
                        segment = new ArraySegment<byte>(buffer, count, buffer.Length - count);
                        result = await ws.ReceiveAsync(segment, CancellationToken.None);
                        count += result.Count;
                    }
    
                    var message = Encoding.UTF8.GetString(buffer, 0, count);
    
                    // you'll probably want to parse the JSON into a useful object here,
                    // see ServiceState and IsDelimeter for a light-weight example of that.
                    Console.WriteLine(message);
            
                    if (IsDelimeter(message))
                    {
                        return;
                    }
                }
            }
    
    
            // the watson service sends a {"state": "listening"} message at both the beginning and the *end* of the results
            // this checks for that
            [DataContract]
            internal class ServiceState
            {
                [DataMember]
                public string state = "";
            }
            static bool IsDelimeter(String json)
            {
                MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ServiceState));
                ServiceState obj = (ServiceState)ser.ReadObject(stream);
                return obj.state == "listening";
            }
            
        }
    }
