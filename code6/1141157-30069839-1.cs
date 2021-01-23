    logger.DebugFormat(
       "Connection obtained with a client {0} {1} {2} {3}", 
       myClient.Id, 
       myClient.TcpClient.Connected,   
       myClient.TcpClient.Client.LocalEndPoint,
       myClient.TcpClient.Client.RemoteEndPoint
    );
 
