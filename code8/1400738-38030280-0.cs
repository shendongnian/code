    while (true)
            {
                try
                {
                    Socket handler = server.Accept();
    
                    Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientCommunication));
                    clientThread.Start((object)handler);
                    Console.WriteLine("ReceiveThread: " + clientThread.ThreadState);
    
                    clients.Add(handler);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
