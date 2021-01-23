    int s = sock.ReceiveFrom (incoming, ref otherEnd);
    SendPack message = new SendPack();
    using(System.IO.MemoryStream ms = new System.IO.MemoryStream(incoming,0,s)){
        SendPackSerializer sps = new SendPackSerializer();
        message = (SendPack)sps.Deserialize(ms,null,typeof(SendPack));
        print (message);
        ms.Flush();
        ms.Close();
    }
