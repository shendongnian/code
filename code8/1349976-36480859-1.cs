    // create, write data to packet and send it
    var packet = new packet(...);
    packet.Write(id);
    server.send2Server(packet);
    
    // this will block until a message arrives
    server.MessageReceivedEvent.WaitOne();
    
    // msg is now received
    var msg = server.ReadMessage();
    // process received packet below
