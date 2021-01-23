    using Quobject.SocketIoClientDotNet.Client;
    using System.Configuration;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json;
    
    var options = new IO.Options() { IgnoreServerCertificateValidation = true, AutoConnect = true, ForceNew = true };
    options.Transports = new List<string>() { "websocket" };
    _instance = IO.Socket("ws://localhost:3000", options);
    _instance.On(Socket.EVENT_CONNECT, () =>
    {
    	_connected = true;
    	Console.WriteLine("Connected");
    });
    _instance.On(Socket.EVENT_DISCONNECT, () =>
    {
    	_connected = false;
    	Console.WriteLine("Disconnected");
    });
