    public string Receive(NetworkStream stream) {
      byte[] intbuf = new byte[4];
      stream.Read(intbuf, 0, intbuf.Length);
      int length = System.Net.IPAddress.HostToNetworkOrder(BitConverter.ToInt32(intbuf, 0));
      
      byte[] strbuf = new byte[length];
      stream.Read(strbuf, 0, strbuf.Length);
      string message = System.Text.Encoding.UTF8.GetString(strbuf);
      return message;
    }
