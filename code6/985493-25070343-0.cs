    var client = clients.FirstOrDefault(c => c.s.RemoteEndPoint == toclient);
    if(client != null) 
    {
         lock(client.sendlock)
         {
            int size = data.Length;
            byte[] sizebytes = new byte[4];
            sizebytes = BitConverter.GetBytes(size);
            client.s.Send(sizebytes);
            client.s.Send(data);
         }
    }
