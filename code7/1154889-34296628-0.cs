	using System;
	using System.Web;
	using System.Text;
	using System.Threading;
	using System.Threading.Tasks;
	using System.Net.WebSockets;
	namespace AspNetWebSocketEcho
	{
		public class EchoHandler : IHttpHandler
		{
			public void ProcessRequest(HttpContext context)
			{
				if (context.IsWebSocketRequest)
					context.AcceptWebSocketRequest(HandleWebSocket);
				else
					context.Response.StatusCode = 400;
			}
			
			private async Task HandleWebSocket(WebSocketContext wsContext)
			{
				const int maxMessageSize = 1024;
				byte[] receiveBuffer = new byte[maxMessageSize];
				WebSocket socket = wsContext.WebSocket;
				
				while (socket.State == WebSocketState.Open)
				{
					WebSocketReceiveResult receiveResult = await socket.ReceiveAsync(new ArraySegment<byte>(receiveBuffer), CancellationToken.None);
					if (receiveResult.MessageType == WebSocketMessageType.Close)
					{
						await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
					}
					else if (receiveResult.MessageType == WebSocketMessageType.Binary)
					{
						await socket.CloseAsync(WebSocketCloseStatus.InvalidMessageType, "Cannot accept binary frame", CancellationToken.None);
					}
					else
					{
						int count = receiveResult.Count;
						while (receiveResult.EndOfMessage == false)
						{
							if (count >= maxMessageSize)
							{
								string closeMessage = string.Format("Maximum message size: {0} bytes.", maxMessageSize);
								await socket.CloseAsync(WebSocketCloseStatus.MessageTooLarge, closeMessage, CancellationToken.None);
								return;
							}
							
							receiveResult = await socket.ReceiveAsync(new ArraySegment<byte>(receiveBuffer, count, maxMessageSize - count), CancellationToken.None);
							count += receiveResult.Count;
						}
						
						var receivedString = Encoding.UTF8.GetString(receiveBuffer, 0, count);
						var echoString = "You said " + receivedString;
						ArraySegment<byte> outputBuffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(echoString));
						await socket.SendAsync(outputBuffer, WebSocketMessageType.Text, true, CancellationToken.None);
					}
				}
			}
			
			public bool IsReusable
			{
				get { return true; }
			}
		}
	}
