    public static void Send(Socket socket, byte[] buffer, int offset, int size, int timeout)
    {
      int startTickCount = Environment.TickCount;
      int sent = 0;  // how many bytes is already sent
      do {
        if (Environment.TickCount > startTickCount + timeout)
          throw new Exception("Timeout.");
        try {
          sent += socket.Send(buffer, offset + sent, size - sent, SocketFlags.None);
        }
        catch (SocketException ex)
        {
          if (ex.SocketErrorCode == SocketError.WouldBlock ||
              ex.SocketErrorCode == SocketError.IOPending ||
              ex.SocketErrorCode == SocketError.NoBufferSpaceAvailable)
          {
            // socket buffer is probably full, wait and try again
            Thread.Sleep(30);
          }
          else
            throw ex;  // any serious error occurr
        }
      } while (sent < size);
    }
