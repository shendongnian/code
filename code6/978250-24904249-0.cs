      // The network thread listening to the server
      private void NetworkThread () {
        Debug.Log("Connecting to server...");
        clientSocket = new TcpClient();
        clientSocket.Connect("127.0.0.1", 5000);
        stream = clientSocket.GetStream();
    
        int braces = 0;
        bool inQ = false;
        char lastB = ' ';
        while (!stopThread) {
          char b = (char)stream.ReadByte();
          if (b < 0)
            return;
    
          buffer.Append((char)b);
          if (b == '"' && lastB != '\\') {
            inQ = !inQ;
          }
          else if (b == '{' && !inQ) {
            braces += 1;
          }
          else if (b == '}' && !inQ) {
            braces -= 1;
          }
          lastB = (char)b;
          if (braces == 0) {
            try {
              JSONNode packet = JSONNode.Parse(buffer.ToString());
              buffer = new StringBuilder();
              lock (lockQueue) {
                packetQueue.Enqueue(packet);
              }
            } catch (Exception e) {
            }
          }
        }
      }
