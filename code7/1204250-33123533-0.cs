          WhatsApp wa = new WhatsApp(sender, password, nickname, true, true);
          wa.OnConnectSuccess += () => {
          	Console.WriteLine("Connected");
          	wa.OnLoginSuccess += (phoneNumber, data) => {
          		Console.WriteLine("Connection success!");
          		wa.SendMessage(target, "testing C# Api,sent via C#");
          		Console.WriteLine("Message sent!");
          	};
          	wa.OnLoginFailed += (data) => {
          		Console.WriteLine("Login failed: {0}", data);
          	};
          	wa.Login();
          };
          wa.OnConnectFailed += (ex) => {
          	Console.WriteLine("Connect failed: {0}", ex.StackTrace);
          };
          wa.Connect();
          Console.WriteLine("END");
