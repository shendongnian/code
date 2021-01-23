    string response = null;
    using(var tcpc = new TcpClient())
    {
        tcpc.NoDelay = true;
        tcpc.ExclusiveAddressUse = false;
        tcpc.Connect("172.18.10.100", 4004);
        
        using (var stream = tcpc.GetStream())
        using (var sr = new StreamReader(stream, Encoding.ASCII))
        {
            sr.Peek();
            
            var Message = "IX3543543" + '\r';
            stream.Write(Encoding.ASCII.GetBytes(Message), 0, Message.Length);
            response = sr.ReadToEnd();
        }
    }
    // examine message here
    var lines = response.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
